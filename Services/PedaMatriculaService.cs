using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PlataformaITB.API.Models;
using PlataformaITB.API.Repositories;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace PlataformaITB.API.Services
{
    public class PedaMatriculaService : IPedaMatriculasService
    {
        private readonly IPedaMatriculaRepository _pedaMatriculaRepository;
        private readonly ItbDadosContext _itbDadosContext;

        public PedaMatriculaService(IPedaMatriculaRepository categoryRepository, ItbDadosContext itbDadosContext)
        {
            _pedaMatriculaRepository = categoryRepository;
            _itbDadosContext = itbDadosContext;
        }

        public void ExcluirMatriculaPorCodigo(string codigoMatricula, string loginUsuario)
        {
            var matricula = _itbDadosContext.PedaMatriculas.Include(c => c.IdAlunoNavigation)
                                                           .FirstOrDefault(x => x.CodigoMatricula.Equals(codigoMatricula));

            if (matricula == null)
                throw new NullReferenceException("Matrícula não encontrada");
            else
                ExcluirMatricula(matricula, loginUsuario);
        }

        public void ExcluirMatricula(PedaMatriculas matricula, string loginUsuario)
        {
            using (var dbContextTransaction = _itbDadosContext.Database.BeginTransaction())
            {
                try
                {

                    // Testa tentativa anterior de excluir (evitar erros)
                    var testaMatriculaExcluida = _itbDadosContext.PedaMatriculasExcluidas.SingleOrDefault(m => m.IdMatricula == matricula.IdMatricula);
                    
                    if (testaMatriculaExcluida != null)
                    {
                        _itbDadosContext.PedaMatriculasExcluidas.Remove(testaMatriculaExcluida);
                        _itbDadosContext.SaveChanges();
                    }

                    // Guarda informações
                    PedaMatriculasExcluidas matriculaExcluida = new PedaMatriculasExcluidas()
                    {
                        Curso = matricula.NomeCurso,
                        DataExclusao = DateTime.Now,
                        DataMatricula = matricula.DataCadastrado,
                        IdFrqa = matricula.IdFrqa,
                        IdMatricula = matricula.IdMatricula,
                        NomeAluno = matricula.IdAlunoNavigation.NomeAluno,
                        UsuarioExcluiu = loginUsuario,
                        LoginAluno = matricula.LoginAluno,

                    };

                    // Parcelas 
                    var parcelas = _itbDadosContext.FinaParcelasAlunos.Where(p => p.IdMatricula == matricula.IdMatricula).ToList();
                    var primeiraParcela = parcelas.SingleOrDefault(p => p.Parcela == 1);

                    if (primeiraParcela == null)
                    {
                        matriculaExcluida.Documento = 0;
                        matriculaExcluida.Valor = 0;
                        matriculaExcluida.Vencimento = DateTime.Now;
                        matriculaExcluida.DataPago = DateTime.Now;
                        matriculaExcluida.ValorPago = 0;
                        matriculaExcluida.Lote = 0;
                    }
                    else
                    {
                        matriculaExcluida.Documento = primeiraParcela.Documento;
                        matriculaExcluida.Valor = primeiraParcela.Valor;
                        matriculaExcluida.Vencimento = primeiraParcela.Vencimento;
                        matriculaExcluida.DataPago = primeiraParcela.DataPago;
                        matriculaExcluida.ValorPago = primeiraParcela.ValorPago;
                        matriculaExcluida.Lote = primeiraParcela.IdLote;
                    }

                    _itbDadosContext.PedaMatriculasExcluidas.Add(matriculaExcluida);
                    _itbDadosContext.SaveChanges();

                    foreach (var parcela in parcelas)
                    {
                        var controle = _itbDadosContext.FinaParcelasControle.Single(p => p.Documento == parcela.Documento);
                        _itbDadosContext.FinaParcelasAlunos.Remove(parcela);
                        _itbDadosContext.FinaParcelasControle.Remove(controle);
                    }

                    _itbDadosContext.SaveChanges();

                    // Deleta Anotações
                    var anotacoes = _itbDadosContext.PedaMatriculasAnotacoesAulas.Where(a => a.IdMatricula == matricula.IdMatricula).ToList();
                    _itbDadosContext.PedaMatriculasAnotacoesAulas.RemoveRange(anotacoes);
                    _itbDadosContext.SaveChanges();

                    // Deleta Bônus
                    var bonus = _itbDadosContext.MktgBonusAlunos.Where(b => b.IdMatriculaOrigem == matricula.IdMatricula).ToList();
                    _itbDadosContext.MktgBonusAlunos.RemoveRange(bonus);
                    _itbDadosContext.SaveChanges();

                    // Deleta Documentos
                    var documentos = _itbDadosContext.AcadDocumentosAlunosPostados.Where(d => d.IdMatricula == matricula.IdMatricula).ToList();
                    _itbDadosContext.AcadDocumentosAlunosPostados.RemoveRange(documentos);
                    _itbDadosContext.SaveChanges();

                    // Deleta Dúvidas
                    var duvidas = _itbDadosContext.AvapTiraDuvidas.Where(d => d.IdMatricula == matricula.IdMatricula).ToList();
                    _itbDadosContext.AvapTiraDuvidas.RemoveRange(duvidas);
                    _itbDadosContext.SaveChanges();

                    // Deleta Mensagens
                    var mensagensTutoria = _itbDadosContext.AvapMensagemTutoria.Where(m => m.IdMatricula == matricula.IdMatricula).ToList();
                    _itbDadosContext.AvapMensagemTutoria.RemoveRange(mensagensTutoria);
                    _itbDadosContext.SaveChanges();

                    // Deleta Matrículs
                    _itbDadosContext.PedaMatriculas.Remove(matricula);
                    _itbDadosContext.SaveChanges();

                    // Atualiza Turma
                    var turma = _itbDadosContext.PedaCursosTurmas.SingleOrDefault(t => t.IdTurma == matricula.IdTurma);

                    if (turma != null)
                        AtualizarTurma(turma.IdTurma);

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception("Erro ao deletar matrícula");                    
                }
            }           
        }

        private void AtualizarTurma(int idTurma)
        {
            var turma = _itbDadosContext.PedaCursosTurmas.Single(t => t.IdTurma == idTurma);
            var matriculas = _itbDadosContext.PedaMatriculas.Where(m => m.IdTurma == idTurma && m.IsCancelada == false && m.IsConcluso == false).ToList();

            turma.Inscritos = Convert.ToByte(matriculas.Count());
            _itbDadosContext.SaveChanges();
        }

        //private void DeleteAllObjects<TEntity>(this ObjectSet<TEntity> set, IEnumerable<TEntity> data) where TEntity : class
        //{
        //    foreach (var entity in data.ToList()) //data.ToList() makes a copy of data for safe enumeration
        //        set.DeleteObject(entity);
        //}

        public PedaMatriculas ObterMatricula(int id)
        {
            return _pedaMatriculaRepository.GetByID(id);
        }

        public PedaMatriculas ObterMatriculaDynamic(int id)
        {
            return _itbDadosContext.PedaMatriculas.Include(c => c.IdCursoNavigation).FirstOrDefault(x => x.IdMatricula == id);
            //return _itbDadosContext.PedaMatriculas.Where(matricula => matricula.IdMatricula == id ).Select(c => new { c.IdMatricula, c.IdAluno, c.IdAlunoNavigation });
        }

        public PedaMatriculas ObterMatriculaPorCodigoMatricula(string codigoMatricula)
        {
            var matricula = _itbDadosContext.PedaMatriculas.FirstOrDefault(x => x.CodigoMatricula == codigoMatricula);

            if (matricula == null)
                throw new NullReferenceException("Matrícula não encontrada");

            return matricula;
            //return _itbDadosContext.PedaMatriculas.Where(matricula => matricula.IdMatricula == id ).Select(c => new { c.IdMatricula, c.IdAluno, c.IdAlunoNavigation });
        }
    }
}

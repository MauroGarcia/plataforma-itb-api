using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaCursos
    {
        public PedaCursos()
        {
            AvapMensagemTutoria = new HashSet<AvapMensagemTutoria>();
            AvapTiraDuvidas = new HashSet<AvapTiraDuvidas>();
            PedaMatriculas = new HashSet<PedaMatriculas>();
        }

        public int IdCurso { get; set; }
        public int? IdTipo { get; set; }
        public int? IdBlocoAcolhimento { get; set; }
        public string TipoCurso { get; set; }
        public string TipoCursoFormacaoTecnica { get; set; }
        public string NomeCurso { get; set; }
        public string NomeCursoFormacaoTecnica { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }
        public string Publico { get; set; }
        public string Ementa { get; set; }
        public string ProjetoPedagogico { get; set; }
        public string CertificadoNomeInstituicao { get; set; }
        public string CertificadoCriacaoCurso { get; set; }
        public string CertificadoAutorizacaoInstituicao { get; set; }
        public string CertificadoLocalCertificacao { get; set; }
        public string Certificacao { get; set; }
        public string CertificadoVersoColunaEsq { get; set; }
        public string CertificadoVersoColunaCen { get; set; }
        public string CertificadoVersoColunaDir { get; set; }
        public string ItinerarioFormativo { get; set; }
        public string VideoDeApresentacao { get; set; }
        public string ImagemPublico { get; set; }
        public string IconePublico { get; set; }
        public string ImagemBgAva { get; set; }
        public string CorBgAva { get; set; }
        public string Objetivos { get; set; }
        public string PerfilProfissional { get; set; }
        public string Metodologia { get; set; }
        public int CargaHoraria { get; set; }
        public string Duracao { get; set; }
        public string PrecoSugerido { get; set; }
        public string InfoCargaHoraria { get; set; }
        public string InfoInvestimento { get; set; }
        public decimal? FequenciaMinima { get; set; }
        public byte QtdModulos { get; set; }
        public byte QtdAvaliacoes { get; set; }
        public decimal? MediaAprovacao { get; set; }
        public decimal? MediaRecuperacao { get; set; }
        public decimal? FaltasMaximo { get; set; }
        public bool IsAtivo { get; set; }

        public virtual ICollection<AvapMensagemTutoria> AvapMensagemTutoria { get; set; }
        public virtual ICollection<AvapTiraDuvidas> AvapTiraDuvidas { get; set; }
        public virtual ICollection<PedaMatriculas> PedaMatriculas { get; set; }
    }
}

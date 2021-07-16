using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaMatriculas
    {
        public PedaMatriculas()
        {
            AcadDocumentosAlunosPostados = new HashSet<AcadDocumentosAlunosPostados>();
            AcadProficienciaAcademica = new HashSet<AcadProficienciaAcademica>();
            AvapMensagemTutoria = new HashSet<AvapMensagemTutoria>();
            AvapTiraDuvidas = new HashSet<AvapTiraDuvidas>();
            FinaParcelasAlunos = new HashSet<FinaParcelasAlunos>();
            MktgBonusAlunosIdMatriculaDestinoNavigation = new HashSet<MktgBonusAlunos>();
            MktgBonusAlunosIdMatriculaOrigemNavigation = new HashSet<MktgBonusAlunos>();
            PedaMatriculasAnotacoes = new HashSet<PedaMatriculasAnotacoes>();
            PedaMatriculasAnotacoesAulas = new HashSet<PedaMatriculasAnotacoesAulas>();
        }

        public int IdMatricula { get; set; }
        public string CodigoMatricula { get; set; }
        public string TipoCurso { get; set; }
        public string NomeCurso { get; set; }
        public bool? IsFormacaoTecnica { get; set; }
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }
        public int IdBlocoAtual { get; set; }
        public int IdBlocoEntrada { get; set; }
        public DateTime DataInicioAtividades { get; set; }
        public DateTime DataFimAtividades { get; set; }
        public DateTime DataFimContrato { get; set; }
        public bool? IsPrimeiroAcesso { get; set; }
        public DateTime? DataPrimeiroAcesso { get; set; }
        public DateTime? DataUltimoAcesso { get; set; }
        public int? IdTurma { get; set; }
        public int? IdTutorLocal { get; set; }
        public int? IdTutorVirtual { get; set; }
        public bool IsBolsaConvenio { get; set; }
        public int? CodigoBolsa { get; set; }
        public bool IsPagseguro { get; set; }
        public string CodigoNossoTransacaoPs { get; set; }
        public string CodigoTransacaoPs { get; set; }
        public DateTime? DataTransacaoPs { get; set; }
        public string StatusPs { get; set; }
        public DateTime? DataStatusPs { get; set; }
        public bool? IsTransacaoCompleta { get; set; }
        public DateTime? DataTransacaoCompleta { get; set; }
        public int IdPrecificacaoFrqa { get; set; }
        public decimal? ValorMatricula { get; set; }
        public decimal? ValorParcela { get; set; }
        public int? QtdParcelas { get; set; }
        public decimal DescontoDePontualidade { get; set; }
        public bool IsCombo { get; set; }
        public int IdFrqa { get; set; }
        public int? IdFrqaMaster { get; set; }
        public int? IdFrqaVendedor { get; set; }
        public int IdOpcaoCertificado { get; set; }
        public string LoginAluno { get; set; }
        public DateTime? DataCertificado { get; set; }
        public bool IsImpressoCertificado { get; set; }
        public string ImpressoPor { get; set; }
        public string InformacoesPostagem { get; set; }
        public string InformacoesRegistro { get; set; }
        public string CodigoAutenticacaoExterno { get; set; }
        public string SiteAutenticacaoExterno { get; set; }
        public bool IsMatriculaNova { get; set; }
        public bool IsBloqueada { get; set; }
        public bool? IsPendente { get; set; }
        public bool IsFornecerCertificado { get; set; }
        public bool IsPagoMatricula { get; set; }
        public DateTime DataLimitePagoMatricula { get; set; }
        public bool IsMatriculaQuitada { get; set; }
        public bool IsInadimplente { get; set; }
        public byte QtdParcelasInad { get; set; }
        public DateTime? DataCalculoInad { get; set; }
        public bool IsAprovado { get; set; }
        public bool IsConcluso { get; set; }
        public bool IsEvadiu { get; set; }
        public bool IsTrancada { get; set; }
        public bool IsCancelada { get; set; }
        public string MotivoCancelamento { get; set; }
        public DateTime? DataCancelou { get; set; }
        public string UsuarioCancelou { get; set; }
        public DateTime DataCadastrado { get; set; }
        public string UsuarioCadastrou { get; set; }
        public string LoteNewsletter { get; set; }
        public DateTime? DataNewsletter { get; set; }
        public bool IsDocumentacaoPostada { get; set; }
        public DateTime? DataDocumantacaoPostada { get; set; }
        public string DocumentacaoPostadaPor { get; set; }
        public bool IsDocumentacaoOk { get; set; }
        public string DocumentacaoConferidaPor { get; set; }
        public string ObsDocumentacao { get; set; }
        public string Identificacao01 { get; set; }
        public string Identificacaio02 { get; set; }
        public byte ModulosaCursar { get; set; }
        public byte ModulosCursados { get; set; }
        public decimal PercentualCursado { get; set; }
        public bool IsTesteInterno { get; set; }
        public string TutorLocalPreferencial { get; set; }
        public string TutorCentralPreferencial { get; set; }
        public bool? IsLiberaTutoria { get; set; }
        public bool? IsLiberaAvPresencial { get; set; }
        public bool? IsOficinaConcluida { get; set; }
        public bool? IsExperimental { get; set; }
        public DateTime? DataInicioPeriodoExperimental { get; set; }

        public virtual PedaAlunos IdAlunoNavigation { get; set; }
        public virtual PedaCursosBlocosTematicos IdBlocoAtualNavigation { get; set; }
        public virtual PedaCursos IdCursoNavigation { get; set; }
        public virtual PedaCursosTurmas IdTurmaNavigation { get; set; }
        public virtual ICollection<AcadDocumentosAlunosPostados> AcadDocumentosAlunosPostados { get; set; }
        public virtual ICollection<AcadProficienciaAcademica> AcadProficienciaAcademica { get; set; }
        public virtual ICollection<AvapMensagemTutoria> AvapMensagemTutoria { get; set; }
        public virtual ICollection<AvapTiraDuvidas> AvapTiraDuvidas { get; set; }
        public virtual ICollection<FinaParcelasAlunos> FinaParcelasAlunos { get; set; }
        public virtual ICollection<MktgBonusAlunos> MktgBonusAlunosIdMatriculaDestinoNavigation { get; set; }
        public virtual ICollection<MktgBonusAlunos> MktgBonusAlunosIdMatriculaOrigemNavigation { get; set; }
        public virtual ICollection<PedaMatriculasAnotacoes> PedaMatriculasAnotacoes { get; set; }
        public virtual ICollection<PedaMatriculasAnotacoesAulas> PedaMatriculasAnotacoesAulas { get; set; }
    }
}

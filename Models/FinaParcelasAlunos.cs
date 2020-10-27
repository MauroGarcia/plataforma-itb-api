using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class FinaParcelasAlunos
    {
        public int IdParcela { get; set; }
        public int IdMatricula { get; set; }
        public int IdCedente { get; set; }
        public int Documento { get; set; }
        public byte Parcela { get; set; }
        public decimal Valor { get; set; }
        public bool IsDescontoAntecipado { get; set; }
        public decimal DescontoAntecipado { get; set; }
        public DateTime Emissao { get; set; }
        public string UsuarioEmitiu { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime VencimentoReal { get; set; }
        public DateTime? DataPago { get; set; }
        public string LocalPago { get; set; }
        public decimal? ValorPago { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? Tarifa { get; set; }
        public DateTime? DataBaixado { get; set; }
        public string UsuarioBaixou { get; set; }
        public bool IsDivergencia { get; set; }
        public bool IsCancelado { get; set; }
        public bool IsPago { get; set; }
        public bool IsPagoEmDuplicidade { get; set; }
        public bool IsBaixadoPorDuplicidade { get; set; }
        public bool IsInadimplente { get; set; }
        public bool IsAcordo { get; set; }
        public byte? OptAcordo { get; set; }
        public int? TransacaoId { get; set; }
        public string TipoPagamento { get; set; }
        public string Urlboleto { get; set; }
        public int? Status { get; set; }
        public DateTime? DataStatus { get; set; }
        public bool? IsTransacaoCompleta { get; set; }
        public DateTime? DataTransacaoCompleta { get; set; }
        public decimal PercentualOperacional { get; set; }
        public decimal ValorOperacional { get; set; }
        public decimal PercentualFrqa { get; set; }
        public decimal ValorFrqa { get; set; }
        public decimal? PercentualFrqaMaster { get; set; }
        public decimal? ValorFrqaMaster { get; set; }
        public decimal? PercentualFrqaVendedor { get; set; }
        public decimal? ValorFrqaVendedor { get; set; }
        public decimal? PercentualImpostoRetido { get; set; }
        public decimal? ValorImpostoRetido { get; set; }
        public bool IsValorFrqaRepassado { get; set; }
        public bool IsTratadoCobranca { get; set; }
        public int? IdLote { get; set; }
        public decimal ValorOriginal { get; set; }
        public bool IsBonus { get; set; }
        public decimal? DescontoBonus { get; set; }
        public decimal? ValorDescontoBonus { get; set; }
        public bool IsCampanha { get; set; }
        public decimal? ValoParcelaCampanha { get; set; }
        public decimal? PercentualFrqaCampanha { get; set; }
        public decimal? ValorFrqaCampanha { get; set; }
        public bool IsCombo { get; set; }
        public int? IdCompra { get; set; }

        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
    }
}

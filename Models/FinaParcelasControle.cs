using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class FinaParcelasControle
    {
        public int IdEmissao { get; set; }
        public int IdCedente { get; set; }
        public int Documento { get; set; }
        public byte Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public bool? IsPago { get; set; }
        public DateTime? DataProcessado { get; set; }
        public int? IdLote { get; set; }
    }
}

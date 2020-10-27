using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaMatriculasExcluidas
    {
        public int IdMatricula { get; set; }
        public string LoginAluno { get; set; }
        public int IdFrqa { get; set; }
        public string NomeAluno { get; set; }
        public string Curso { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime DataExclusao { get; set; }
        public string UsuarioExcluiu { get; set; }
        public int Documento { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataPago { get; set; }
        public decimal? ValorPago { get; set; }
        public int? Lote { get; set; }
    }
}

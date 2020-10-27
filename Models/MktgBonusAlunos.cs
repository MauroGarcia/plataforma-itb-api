using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class MktgBonusAlunos
    {
        public int IdBonus { get; set; }
        public int IdCampanhaBonus { get; set; }
        public int IdMatriculaOrigem { get; set; }
        public int? IdMatriculaDestino { get; set; }
        public decimal DescontoOrigem { get; set; }
        public decimal DescontoDestino { get; set; }
        public DateTime DataSolicitado { get; set; }
        public bool IsUtilizado { get; set; }
        public DateTime? DataUtilizado { get; set; }
        public string UsuarioLancou { get; set; }

        public virtual PedaMatriculas IdMatriculaDestinoNavigation { get; set; }
        public virtual PedaMatriculas IdMatriculaOrigemNavigation { get; set; }
    }
}

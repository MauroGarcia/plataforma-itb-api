using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaCursosBlocosTematicos
    {
        public PedaCursosBlocosTematicos()
        {
            PedaCursosModulos = new HashSet<PedaCursosModulos>();
            PedaMatriculas = new HashSet<PedaMatriculas>();
        }

        public int IdBloco { get; set; }
        public byte SeqBlocoTematico { get; set; }
        public string BlocoTematico { get; set; }
        public int IdCurso { get; set; }
        public decimal Horas { get; set; }
        public bool? IsAtivo { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? PeriodoIni { get; set; }
        public DateTime? PeriodoFim { get; set; }

        public virtual PedaCursos IdCursoNavigation { get; set; }
        public virtual ICollection<PedaCursosModulos> PedaCursosModulos { get; set; }
        public virtual ICollection<PedaMatriculas> PedaMatriculas { get; set; }
    }
}

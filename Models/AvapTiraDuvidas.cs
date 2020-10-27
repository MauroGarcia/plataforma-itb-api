using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class AvapTiraDuvidas
    {
        public int IdDuvida { get; set; }
        public DateTime Data { get; set; }
        public string Duvida { get; set; }
        public string Autor { get; set; }
        public string LoginAutor { get; set; }
        public string FotoAutor { get; set; }
        public string TutorPreferencial { get; set; }
        public int IdCurso { get; set; }
        public int IdFrqa { get; set; }
        public int IdMatricula { get; set; }
        public string Resposta { get; set; }
        public bool IsRespondido { get; set; }
        public string RespondidoPor { get; set; }
        public string LoginRespondidoPor { get; set; }
        public string FotoRespondidoPor { get; set; }
        public DateTime? DataRespondido { get; set; }

        public virtual PedaCursos IdCursoNavigation { get; set; }
        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
    }
}

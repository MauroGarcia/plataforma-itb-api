using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaMatriculasAnotacoesAulas
    {
        public int IdAnotacao { get; set; }
        public int IdMatricula { get; set; }
        public int? IdAtividade { get; set; }
        public string TempodeAula { get; set; }
        public string TextoAnotacao { get; set; }
        public DateTime? DataAnotacao { get; set; }

        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
    }
}

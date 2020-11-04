using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaMatriculasAnotacoes
    {
        public int IdAnotacao { get; set; }
        public int IdMatricula { get; set; }
        public string TextoAnotacao { get; set; }
        public DateTime DataAnotacao { get; set; }
        public string UsuarioPostou { get; set; }

        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
    }
}

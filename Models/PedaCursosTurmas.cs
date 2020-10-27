using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaCursosTurmas
    {
        public PedaCursosTurmas()
        {
            PedaMatriculas = new HashSet<PedaMatriculas>();
        }

        public int IdTurma { get; set; }
        public int IdTransmissao { get; set; }
        public int IdFrqa { get; set; }
        public int IdTurno { get; set; }
        public string Horario { get; set; }
        public string Local { get; set; }
        public int Vagas { get; set; }
        public int Inscritos { get; set; }
        public bool IsAberta { get; set; }
        public bool IsSuspensa { get; set; }
        public bool IsEncerrada { get; set; }
        public DateTime DataCadastro { get; set; }
        public string UsuarioCadastrou { get; set; }

        public virtual ICollection<PedaMatriculas> PedaMatriculas { get; set; }
    }
}

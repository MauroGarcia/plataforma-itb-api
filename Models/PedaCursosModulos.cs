using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaCursosModulos
    {
        public PedaCursosModulos()
        {
            AcadProficienciaAcademica = new HashSet<AcadProficienciaAcademica>();
        }

        public int IdModulo { get; set; }
        public int IdCurso { get; set; }
        public int IdBloco { get; set; }
        public byte NumeroModulo { get; set; }
        public string NomeModulo { get; set; }
        public byte Duracao { get; set; }
        public byte? MinimoAluno { get; set; }
        public byte HorasSaladeAula { get; set; }
        public byte Avaliacoes { get; set; }
        public byte VerificacaoAprendizagem { get; set; }
        public byte HorasVerificacaoAprendizagem { get; set; }
        public string AssuntoAbordado { get; set; }
        public bool? IsAtivo { get; set; }
        public bool IsDisponivelAva { get; set; }
        public bool IsEstagio { get; set; }

        public virtual PedaCursosBlocosTematicos IdBlocoNavigation { get; set; }
        public virtual PedaCursos IdCursoNavigation { get; set; }
        public virtual ICollection<AcadProficienciaAcademica> AcadProficienciaAcademica { get; set; }
    }
}

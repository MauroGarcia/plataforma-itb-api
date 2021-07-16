using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class AcadProficienciaAcademica
    {
        public int IdProficiencia { get; set; }
        public int IdMatricula { get; set; }
        public int IdModulo { get; set; }
        public byte QtdAula { get; set; }
        public double HsAula { get; set; }
        public double PtsAula { get; set; }
        public byte QtdAv { get; set; }
        public byte QtdAr { get; set; }
        public double HsAv { get; set; }
        public double HsAr { get; set; }
        public double PtsAv { get; set; }
        public double PtsAr { get; set; }
        public byte QtdVa { get; set; }
        public double HsVa { get; set; }
        public double PtsVa { get; set; }
        public byte QtdAa { get; set; }
        public double HsAa { get; set; }
        public double PtsAa { get; set; }
        public bool IsProficienteHs { get; set; }
        public bool IsProficientePts { get; set; }
        public bool IsProficiente { get; set; }
        public bool IsRecuperacao { get; set; }
        public bool IsSubstitutiva { get; set; }
        public bool IsNivelamento { get; set; }
        public double HsTotal { get; set; }
        public double? PtsAc { get; set; }
        public double PtsTotal { get; set; }

        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
        public virtual PedaCursosModulos IdModuloNavigation { get; set; }
    }
}

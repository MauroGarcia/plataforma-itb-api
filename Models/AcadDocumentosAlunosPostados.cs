using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class AcadDocumentosAlunosPostados
    {
        public int IdPostagem { get; set; }
        public int IdTipo { get; set; }
        public int IdMatricula { get; set; }
        public string ComplementoTipo { get; set; }
        public string NomeSistema { get; set; }
        public DateTime DataPostado { get; set; }
        public string PostadoPor { get; set; }
        public bool IsConferidoSecretariaCentral { get; set; }
        public bool IsDocumentoOk { get; set; }
        public string ConferidoPor { get; set; }
        public bool IsDocumentoRejeitado { get; set; }

        public virtual PedaMatriculas IdMatriculaNavigation { get; set; }
    }
}

using PlataformaITB.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformaITB.API.Services
{
    public interface IPedaMatriculasService
    {
        public void ExcluirMatriculaPorCodigo(string codigoMatricula, string loginUsuario);
        public PedaMatriculas ObterMatricula(int id);

        public PedaMatriculas ObterMatriculaDynamic(int id);

        public PedaMatriculas ObterMatriculaPorCodigoMatricula(string codigoMatricula);
    }
}

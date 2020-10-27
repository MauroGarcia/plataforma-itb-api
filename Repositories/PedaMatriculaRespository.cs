using PlataformaITB.API.Models;
using System;
using System.Threading.Tasks;

namespace PlataformaITB.API.Repositories
{
    public class PedaMatriculaRespository : BaseRepository<PedaMatriculas>, IPedaMatriculaRepository
    {
        public PedaMatriculaRespository(ItbDadosContext context) : base(context)
        {
        }

        public Task<bool> ExcluirAsync()
        {
            throw new NotImplementedException();
            //return await _context.PedaMatriculas.Remove();
        }
    }
}

using PlataformaITB.API.Models;
using System.Threading.Tasks;

namespace PlataformaITB.API.Repositories
{
    public interface IPedaMatriculaRepository : IRepository<PedaMatriculas>
    {
        Task<bool> ExcluirAsync();
    }
}

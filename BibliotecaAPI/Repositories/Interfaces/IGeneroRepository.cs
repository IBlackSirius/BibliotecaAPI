using BibliotecaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetGeneros();
        Task<Genero> GetGeneroById(int id);
        Task AddGenero(Genero genero);
        Task UpdateGenero(Genero genero);
        Task DeleteGenero(int id);
    }
}

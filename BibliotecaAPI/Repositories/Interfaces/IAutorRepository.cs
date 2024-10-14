using BibliotecaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutores();
        Task<Autor> GetAutorById(int id);
        Task AddAutor(Autor autor);
        Task UpdateAutor(Autor autor);
        Task DeleteAutor(int id);
    }
}

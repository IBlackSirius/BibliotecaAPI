using BibliotecaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetLivros();
        Task<Livro> GetLivroById(int id);
        Task AddLivro(Livro livro);
        Task UpdateLivro(Livro livro);
        Task DeleteLivro(int id);
    }
}

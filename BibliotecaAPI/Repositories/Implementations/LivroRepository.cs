using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetLivros() => await _context.Livros.ToListAsync();

        public async Task<Livro> GetLivroById(int id) => await _context.Livros.FindAsync(id);

        public async Task AddLivro(Livro livro)
        {
            try
            {
                await _context.Livros.AddAsync(livro);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
               
            }

        }

        public async Task UpdateLivro(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
        }
    }
}

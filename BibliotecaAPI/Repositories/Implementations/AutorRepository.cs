using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaContext _context;

        public AutorRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor> GetAutorById(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task AddAutor(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAutor(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }
    }
}

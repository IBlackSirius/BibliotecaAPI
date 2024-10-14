using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly BibliotecaContext _context;

        public GeneroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genero>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<Genero> GetGeneroById(int id)
        {
            return await _context.Generos.FindAsync(id);
        }

        public async Task AddGenero(Genero genero)
        {
            await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenero(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }
    }
}

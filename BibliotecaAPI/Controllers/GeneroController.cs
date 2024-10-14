using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly ILivroRepository _livroRepository;

        public GenerosController(IGeneroRepository generoRepository, ILivroRepository livroRepository)
        {
            _generoRepository = generoRepository;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            return Ok(await _generoRepository.GetGeneros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _generoRepository.GetGeneroById(id);
            if (genero == null)
                return NotFound();
            return Ok(genero);
        }

        [HttpPost]
        public async Task<ActionResult> AddGenero([FromBody] Genero genero)
        {
            await _generoRepository.AddGenero(genero);
            return CreatedAtAction(nameof(GetGenero), new { id = genero.ID }, genero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenero(int id, [FromBody] Genero genero)
        {
            if (id != genero.ID)
                return BadRequest();

            await _generoRepository.UpdateGenero(genero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            var livrosAssociados = await _livroRepository.GetLivros();
            if (livrosAssociados.Any(l => l.GeneroID == id))
            {
                return BadRequest("Não é possível deletar o gênero, pois existem livros associados a ele.");
            }
            await _generoRepository.DeleteGenero(id);
            return NoContent();
        }
    }
}

using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return Ok(await _livroRepository.GetLivros());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _livroRepository.GetLivroById(id);
            if (livro == null)
                return NotFound();
            return Ok(livro);
        }

        [HttpPost]
        public async Task<ActionResult> AddLivro([FromBody] Livro livro)
        {
            await _livroRepository.AddLivro(livro);
            return CreatedAtAction(nameof(GetLivro), new { id = livro.ID }, livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLivro(int id, [FromBody] Livro livro)
        {
            if (id != livro.ID)
                return BadRequest();

            await _livroRepository.UpdateLivro(livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            await _livroRepository.DeleteLivro(id);
            return NoContent();
        }
    }
}

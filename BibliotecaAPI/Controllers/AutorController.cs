using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Implementations;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;


        public AutoresController(IAutorRepository autorRepository, ILivroRepository livroRepository)
        {
            _autorRepository = autorRepository;
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return Ok(await _autorRepository.GetAutores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _autorRepository.GetAutorById(id);
            if (autor == null)
                return NotFound();
            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> AddAutor([FromBody] Autor autor)
        {
            
            await _autorRepository.AddAutor(autor);
            return CreatedAtAction(nameof(GetAutor), new { id = autor.ID }, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutor(int id, [FromBody] Autor autor)
        {            
            if (autor == null)
            {                
                return BadRequest("Autor não pode ser nulo");
            }

            if (id != autor.ID)
            {                
                return BadRequest("ID da URL não corresponde ao ID do corpo da requisição");
            }

            await _autorRepository.UpdateAutor(autor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {

            var livrosAssociados = await _livroRepository.GetLivros();
            if (livrosAssociados.Any(l => l.AutorID == id))
            {
                return BadRequest("Não é possível deletar o autor, pois existem livros associados a ele.");
            }
            await _autorRepository.DeleteAutor(id);
            return NoContent();
        }
    }
}

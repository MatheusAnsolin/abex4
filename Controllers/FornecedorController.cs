using SiteBrecho.Models;
using SiteBrecho.Services;
using Microsoft.AspNetCore.Mvc;

namespace SiteBrecho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }
 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fornecedores = await _fornecedorService.ObterFornecedorAsync();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _fornecedorService.ObterIdFornecedorAsync(id);
            if (fornecedor == null)
                return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FornecedorModel fornecedor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var novoFornecedor = await _fornecedorService.AdicionarFornecedorAsync(fornecedor);
            return CreatedAtAction(nameof(GetById), new { id = novoFornecedor.Id }, novoFornecedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FornecedorModel fornecedor)
        {
            if (id != fornecedor.Id)
                return BadRequest();
            var atualizado = await _fornecedorService.AtualizarFornecedorAsync(fornecedor);
            if (atualizado == null)
                return NotFound();
            return Ok(atualizado);
        }

    }
}
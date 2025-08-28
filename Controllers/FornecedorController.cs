using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Models;
using SiteBrecho.Services;

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
            var fornecedores = await _fornecedorService.GetAllAsync();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _fornecedorService.GetByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest();
            }

            var createdFornecedor = await _fornecedorService.CreateAsync(fornecedor);
            return CreatedAtAction(nameof(GetById), new { id = createdFornecedor.Id }, createdFornecedor);
        }
    }
}
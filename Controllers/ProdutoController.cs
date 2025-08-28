using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var produtos = await _produtoService.GetAllProductsAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var produto = await _produtoService.GetProductByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProdutoModel produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoCriado = await _produtoService.CreateProductAsync(produto);
            return CreatedAtAction(nameof(GetProduct), new { id = produtoCriado.Id }, produtoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProdutoModel produto)
        {
            if (id != produto.Id)
            {
                return BadRequest("IDs não correspondem.");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var sucesso = await _produtoService.UpdateProductAsync(id, produto);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
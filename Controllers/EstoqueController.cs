using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Models;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estoques = await _estoqueService.GetAllStocksAsync();
            return Ok(estoques);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estoque = await _estoqueService.GetStockByIdAsync(id);
            if (estoque == null) return NotFound();
            return Ok(estoque);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUpdateEstoqueDto dto)
        {
            var estoque = await _estoqueService.CreateStockAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = estoque.ProdutoId }, estoque);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateEstoqueDto dto)
        {
            var updated = await _estoqueService.UpdateStockAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _estoqueService.DeleteStockAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
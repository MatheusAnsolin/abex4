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
        public async Task<IActionResult> GetAll([FromQuery] int? pageNumber, [FromQuery] int? pageSize, [FromQuery] bool includeInactive = false)
        {
            if (pageNumber.HasValue || pageSize.HasValue)
            {
                var parameters = new PaginationParameters
                {
                    PageNumber = pageNumber ?? 1,
                    PageSize = pageSize ?? 10
                };

                var pagedResult = await _estoqueService.GetAllStocksPagedAsync(parameters, includeInactive);
                return Ok(pagedResult);
            }

            var estoques = await _estoqueService.GetAllStocksAsync(includeInactive);
            return Ok(estoques);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estoque = await _estoqueService.GetStockByIdAsync(id);
            if (estoque == null) return NotFound();
            return Ok(estoque);
        }

        [HttpGet("by-sku/{produtoSkuId:int}")]
        public async Task<IActionResult> GetByProdutoSkuId(int produtoSkuId)
        {
            var estoque = await _estoqueService.GetStockByProdutoSkuIdAsync(produtoSkuId);
            if (estoque == null) return NotFound();
            return Ok(estoque);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEstoqueDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estoque = await _estoqueService.CreateStockAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = estoque.ProdutoSkuId }, estoque);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEstoqueDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _estoqueService.UpdateStockAsync(id, dto);
            if (!updated) return NotFound("Estoque não encontrado para atualização.");
            return NoContent();
        }

        [HttpPut("by-sku/{produtoSkuId:int}")]
        public async Task<IActionResult> UpdateBySkuId(int produtoSkuId, [FromBody] UpdateEstoqueDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _estoqueService.UpdateStockBySkuIdAsync(produtoSkuId, dto);
            if (!updated) return NotFound("Estoque não encontrado para atualização.");
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _estoqueService.DeleteStockAsync(id);
            if (!deleted) return NotFound("Estoque não encontrado para exclusão.");
            return NoContent();
        }

        [HttpPatch("{id:int}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var success = await _estoqueService.ActivateStockAsync(id);
            if (!success) return NotFound("Estoque não encontrado ou já foi excluído.");
            return NoContent();
        }

        [HttpPatch("{id:int}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var success = await _estoqueService.DeactivateStockAsync(id);
            if (!success) return NotFound("Estoque não encontrado ou já foi excluído.");
            return NoContent();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoSkuController : ControllerBase
    {
        private readonly IProdutoSkuService _produtoSkuService;
        private readonly IMapper _mapper;

        public ProdutoSkuController(IProdutoSkuService produtoSkuService, IMapper mapper)
        {
            _produtoSkuService = produtoSkuService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProductSku([FromQuery] int? pageNumber, [FromQuery] int? pageSize, [FromQuery] bool includeInactive = false)
        {
            // Se pageNumber ou pageSize forem fornecidos, usa paginação
            if (pageNumber.HasValue || pageSize.HasValue)
            {
                var parameters = new SiteBrecho.Dtos.PaginationParameters
                {
                    PageNumber = pageNumber ?? 1,
                    PageSize = pageSize ?? 10
                };

                var pagedResult = await _produtoSkuService.GetAllProductSkuPagedAsync(parameters, includeInactive);

                var pagedDto = new SiteBrecho.Dtos.PagedResult<ProdutoSKUDto>
                {
                    Data = _mapper.Map<IEnumerable<ProdutoSKUDto>>(pagedResult.Data),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalRecords = pagedResult.TotalRecords,
                    TotalPages = pagedResult.TotalPages
                };

                return Ok(pagedDto);
            }

            // Se não houver parâmetros de paginação, retorna todos
            var produtosSku = await _produtoSkuService.GetAllProductSkuAsync(includeInactive);
            var produtosSkuDto = _mapper.Map<IEnumerable<ProdutoSKUDto>>(produtosSku);
            return Ok(produtosSkuDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoSKUDto>> GetProductSku(int id)
        {
            var produtoSku = await _produtoSkuService.GetProductSkuByIdAsync(id);
            if (produtoSku == null)
            {
                return NotFound();
            }
            var produtoSkuDto = _mapper.Map<ProdutoSKUDto>(produtoSku);
            return Ok(produtoSkuDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductSku([FromBody] CreateUpdateProductSkuDto produtoSkuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoSku = _mapper.Map<ProdutoSkuModel>(produtoSkuDto);

            var produtoSkuCriado = await _produtoSkuService.CreateProductSkuAsync(produtoSku);

            var produtoSkuRetornoDto = _mapper.Map<ProdutoSKUDto>(produtoSkuCriado);

            return CreatedAtAction(nameof(GetProductSku), new { id = produtoSkuCriado.Id }, produtoSkuRetornoDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductSku(int id, [FromBody] CreateUpdateProductSkuDto produtoSkuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoSku = _mapper.Map<ProdutoSkuModel>(produtoSkuDto);
            produtoSku.Id = id;

            var sucesso = await _produtoSkuService.UpdateProductSkuAsync(id, produtoSku);
            if (!sucesso)
            {
                return NotFound("SKU do produto não encontrada para atualização.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductSku(int id)
        {
            var sucesso = await _produtoSkuService.DeleteProductSkuAsync(id);
            if (!sucesso)
            {
                return NotFound("SKU do produto não encontrada para exclusão.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/activate")]
        public async Task<IActionResult> ActivateProductSku(int id)
        {
            var sucesso = await _produtoSkuService.ActivateProductSkuAsync(id);
            if (!sucesso)
            {
                return NotFound("SKU do produto não encontrada ou já foi excluída.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/deactivate")]
        public async Task<IActionResult> DeactivateProductSku(int id)
        {
            var sucesso = await _produtoSkuService.DeactivateProductSkuAsync(id);
            if (!sucesso)
            {
                return NotFound("SKU do produto não encontrada ou já foi excluída.");
            }

            return NoContent();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoVariationController : ControllerBase
    {
        private readonly IProdutoVariationService _variationService;
        private readonly IMapper _mapper;

        public ProdutoVariationController(IProdutoVariationService variationService, IMapper mapper)
        {
            _variationService = variationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllVariations([FromQuery] int? pageNumber, [FromQuery] int? pageSize, [FromQuery] bool includeInactive = false)
        {
            // Se pageNumber ou pageSize forem fornecidos, usa paginação
            if (pageNumber.HasValue || pageSize.HasValue)
            {
                var parameters = new SiteBrecho.Dtos.PaginationParameters
                {
                    PageNumber = pageNumber ?? 1,
                    PageSize = pageSize ?? 10
                };

                var pagedResult = await _variationService.GetAllVariationsPagedAsync(parameters, includeInactive);

                var pagedDto = new SiteBrecho.Dtos.PagedResult<ProdutoVariationDto>
                {
                    Data = _mapper.Map<IEnumerable<ProdutoVariationDto>>(pagedResult.Data),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalRecords = pagedResult.TotalRecords,
                    TotalPages = pagedResult.TotalPages
                };

                return Ok(pagedDto);
            }

            // Se não houver parâmetros de paginação, retorna todos
            var variations = await _variationService.GetAllVariationsAsync(includeInactive);
            var variationsDto = _mapper.Map<IEnumerable<ProdutoVariationDto>>(variations);
            return Ok(variationsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoVariationDto>> GetVariation(int id)
        {
            var variation = await _variationService.GetVariationByIdAsync(id);
            if (variation == null)
            {
                return NotFound();
            }
            var variationDto = _mapper.Map<ProdutoVariationDto>(variation);
            return Ok(variationDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertVariation([FromBody] CreateUpdateProdutoVariationDto variationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variation = _mapper.Map<ProdutoVariationModel>(variationDto);

            var variationCriada = await _variationService.CreateVariationAsync(variation);

            var variationRetornoDto = _mapper.Map<ProdutoVariationDto>(variationCriada);

            return CreatedAtAction(nameof(GetVariation), new { id = variationCriada.Id }, variationRetornoDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVariation(int id, [FromBody] CreateUpdateProdutoVariationDto variationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variation = _mapper.Map<ProdutoVariationModel>(variationDto);
            variation.Id = id;

            var sucesso = await _variationService.UpdateVariationAsync(id, variation);
            if (!sucesso)
            {
                return NotFound("Variação de produto não encontrada para atualização.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVariation(int id)
        {
            var sucesso = await _variationService.DeleteVariationAsync(id);
            if (!sucesso)
            {
                return NotFound("Variação de produto não encontrada para exclusão.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/activate")]
        public async Task<IActionResult> ActivateVariation(int id)
        {
            var sucesso = await _variationService.ActivateVariationAsync(id);
            if (!sucesso)
            {
                return NotFound("Variação de produto não encontrada ou já foi excluída.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/deactivate")]
        public async Task<IActionResult> DeactivateVariation(int id)
        {
            var sucesso = await _variationService.DeactivateVariationAsync(id);
            if (!sucesso)
            {
                return NotFound("Variação de produto não encontrada ou já foi excluída.");
            }

            return NoContent();
        }
    }
}


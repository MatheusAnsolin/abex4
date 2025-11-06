using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
        {
            _fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSuppliers([FromQuery] int? pageNumber, [FromQuery] int? pageSize, [FromQuery] bool includeInactive = false)
        {
            if (pageNumber.HasValue || pageSize.HasValue)
            {
                var parameters = new SiteBrecho.Dtos.PaginationParameters
                {
                    PageNumber = pageNumber ?? 1,
                    PageSize = pageSize ?? 10
                };

                var pagedResult = await _fornecedorService.GetAllSupplierPagedAsync(parameters, includeInactive);

                var pagedDto = new SiteBrecho.Dtos.PagedResult<FornecedorDto>
                {
                    Data = _mapper.Map<IEnumerable<FornecedorDto>>(pagedResult.Data),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalRecords = pagedResult.TotalRecords,
                    TotalPages = pagedResult.TotalPages
                };

                return Ok(pagedDto);
            }

            var fornecedores = await _fornecedorService.GetAllSupplierAsync(includeInactive);
            var fornecedoresDto = _mapper.Map<IEnumerable<FornecedorDto>>(fornecedores);
            return Ok(fornecedoresDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FornecedorDto>> GetSupplier(int id)
        {
            var fornecedor = await _fornecedorService.GetSupplierByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedor);
            return Ok(fornecedorDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertSupplier([FromBody] CreateUpdateFornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = _mapper.Map<FornecedorModel>(fornecedorDto);

            var fornecedorCriado = await _fornecedorService.CreateSupplierAsync(fornecedor);

            var fornecedorRetornoDto = _mapper.Map<FornecedorDto>(fornecedorCriado);

            return CreatedAtAction(nameof(GetSupplier), new { id = fornecedorCriado.Id }, fornecedorRetornoDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] CreateUpdateFornecedorDto fornecedorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = _mapper.Map<FornecedorModel>(fornecedorDto);
            fornecedor.Id = id;

            var sucesso = await _fornecedorService.UpdateSupplierAsync(id, fornecedor);
            if (!sucesso)
            {
                return NotFound("Fornecedor não encontrado para atualização.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var sucesso = await _fornecedorService.DeleteSupplierAsync(id);
            if (!sucesso)
            {
                return NotFound("Fornecedor não encontrado para exclusão.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/activate")]
        public async Task<IActionResult> ActivateSupplier(int id)
        {
            var sucesso = await _fornecedorService.ActivateSupplierAsync(id);
            if (!sucesso)
            {
                return NotFound("Fornecedor não encontrado ou já foi excluído.");
            }

            return NoContent();
        }

        [HttpPatch("{id:int}/deactivate")]
        public async Task<IActionResult> DeactivateSupplier(int id)
        {
            var sucesso = await _fornecedorService.DeactivateSupplierAsync(id);
            if (!sucesso)
            {
                return NotFound("Fornecedor não encontrado ou já foi excluído.");
            }

            return NoContent();
        }
    }
}
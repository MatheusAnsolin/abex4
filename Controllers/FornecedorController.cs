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
        public async Task<ActionResult<IEnumerable<FornecedorDto>>> GetAllSuppliers()
        {
            var fornecedores = await _fornecedorService.GetAllSupplierAsync();
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

            return CreatedAtAction(nameof(GetSupplier), new { id = fornecedorCriado.Id }, fornecedorCriado);
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
    }
}
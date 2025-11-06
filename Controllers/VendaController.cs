using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public VendaController(IVendaService vendaService, IMapper mapper)
        {
            _vendaService = vendaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendas([FromQuery] int? pageNumber, [FromQuery] int? pageSize, [FromQuery] bool includeInactive = false)
        {
            if (pageNumber.HasValue || pageSize.HasValue)
            {
                var parameters = new PaginationParameters
                {
                    PageNumber = pageNumber ?? 1,
                    PageSize = pageSize ?? 10
                };

                var pagedResult = await _vendaService.GetAllVendasPagedAsync(parameters, includeInactive);

                var pagedDto = new PagedResult<VendaDto>
                {
                    Data = _mapper.Map<IEnumerable<VendaDto>>(pagedResult.Data),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalRecords = pagedResult.TotalRecords,
                    TotalPages = pagedResult.TotalPages
                };

                return Ok(pagedDto);
            }

            var vendas = await _vendaService.GetAllVendasAsync(includeInactive);
            var vendasDto = _mapper.Map<IEnumerable<VendaDto>>(vendas);
            return Ok(vendasDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVendaById(int id)
        {
            var venda = await _vendaService.GetVendaByIdAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            var vendaDto = _mapper.Map<VendaDto>(venda);
            return Ok(vendaDto);
        }

        [HttpPost]
        public async Task<IActionResult> InserirVenda([FromBody] CreateVendaDto vendaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var novaVenda = await _vendaService.CriarVendaAsync(vendaDto);
                var vendaRetornoDto = _mapper.Map<VendaDto>(novaVenda);
                return CreatedAtAction(nameof(GetVendaById), new { id = novaVenda.Id }, vendaRetornoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


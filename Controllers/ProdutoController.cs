using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService,  IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAllProducts()
        {
            var produtos = await _produtoService.GetAllProductsAsync();
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return Ok(produtosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoDto>> GetProduct(int id)
        {
            var produto = await _produtoService.GetProductByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] CreateUpdateProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = _mapper.Map<ProdutoModel>(produtoDto);
            
            var produtoCriado = await _produtoService.CreateProductAsync(produto);

            var produtoRetornoDto = _mapper.Map<ProdutoDto>(produtoCriado);
            
            return CreatedAtAction(nameof(GetProduct), new { id = produtoCriado.Id }, produtoRetornoDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateUpdateProdutoDto produtoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produto = _mapper.Map<ProdutoModel>(produtoDto);
            produto.Id = id;
            
            var sucesso = await _produtoService.UpdateProductAsync(id, produto);
            if (!sucesso)
            {
                return NotFound("Produto não encontrado para atualização.");
            }

            return NoContent();
        }
    }
}
using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoSkuRepository _produtoSkuRepository;
        private readonly IEstoqueRepository _estoqueRepository;

        public VendaService(
            IVendaRepository vendaRepository,
            IProdutoSkuRepository produtoSkuRepository,
            IEstoqueRepository estoqueRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoSkuRepository = produtoSkuRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task<VendaModel> CriarVendaAsync(CreateVendaDto vendaDto)
        {
            var itensVenda = new List<VendaItemModel>();
            decimal valorTotalVenda = 0;

            foreach (var itemDto in vendaDto.Itens)
            {
                var produtoSku = await _produtoSkuRepository.GetByIdAsync(itemDto.ProdutoSkuId);
                if (produtoSku == null)
                {
                    throw new Exception($"ProdutoSKU com ID {itemDto.ProdutoSkuId} não encontrado.");
                }

                var estoque = await _estoqueRepository.GetByProdutoSkuIdAsync(itemDto.ProdutoSkuId);
                if (estoque == null || estoque.QuantidadeAtual < itemDto.Quantidade)
                {
                    throw new Exception($"Estoque insuficiente para o ProdutoSKU ID {itemDto.ProdutoSkuId}.");
                }

                estoque.QuantidadeAtual -= itemDto.Quantidade;
                estoque.AtualizadoEm = DateTime.UtcNow;
                await _estoqueRepository.UpdateAsync(estoque);

                itensVenda.Add(new VendaItemModel
                {
                    ProdutoSkuId = itemDto.ProdutoSkuId,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnitario = produtoSku.PrecoVenda,
                    ProdutoSku = produtoSku,
                    CriadoEm = DateTime.UtcNow,
                    AtualizadoEm = DateTime.UtcNow
                });

                valorTotalVenda += produtoSku.PrecoVenda * itemDto.Quantidade;
            }

            var novaVenda = new VendaModel
            {
                NomeCliente = vendaDto.NomeCliente,
                DataVenda = DateTime.UtcNow,
                ValorTotal = valorTotalVenda,
                Itens = itensVenda,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            };

            return await _vendaRepository.CreateAsync(novaVenda);
        }

        public async Task<IEnumerable<VendaModel>> GetAllVendasAsync(bool includeInactive = false)
        {
            return await _vendaRepository.GetAllAsync(includeInactive);
        }

        public async Task<PagedResult<VendaModel>> GetAllVendasPagedAsync(PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _vendaRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new PagedResult<VendaModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<VendaModel?> GetVendaByIdAsync(int id)
        {
            return await _vendaRepository.GetByIdAsync(id);
        }
    }
}


using SiteBrecho.Dtos;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueRepository _estoqueRepository;

        public VendaService(
            IVendaRepository vendaRepository,
            IProdutoRepository produtoRepository,
            IEstoqueRepository estoqueRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
            _estoqueRepository = estoqueRepository;
        }

        public async Task<VendaModel> CriarVendaAsync(CreateVendaDto vendaDto)
        {
            var itensVenda = new List<VendaItemModel>();
            decimal valorTotalVenda = 0;

            foreach (var itemDto in vendaDto.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(itemDto.ProdutoId);
                if (produto == null)
                {
                    throw new Exception($"Produto com ID {itemDto.ProdutoId} não encontrado.");
                }

                var estoque = await _estoqueRepository.GetByProdutoIdAsync(itemDto.ProdutoId);
                if (estoque == null || estoque.QuantidadeAtual < itemDto.Quantidade)
                {
                    throw new Exception($"Estoque insuficiente para o produto '{produto.Nome}'.");
                }

                estoque.QuantidadeAtual -= itemDto.Quantidade;
                await _estoqueRepository.UpdateAsync(estoque);

                itensVenda.Add(new VendaItemModel
                {
                    ProdutoId = itemDto.ProdutoId,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnitario = produto.PrecoVenda,
                    Produto = produto
                });

                valorTotalVenda += produto.PrecoVenda * itemDto.Quantidade;
            }

            var novaVenda = new VendaModel
            {
                NomeCliente = vendaDto.NomeCliente,
                DataVenda = DateTime.UtcNow,
                ValorTotal = valorTotalVenda,
                Itens = itensVenda
            };

            return await _vendaRepository.CreateAsync(novaVenda);
        }
    }
}

using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllProductsAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<ProdutoModel?> GetProductByIdAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<ProdutoModel> CreateProductAsync(ProdutoModel produto)
        {
            // Regra de negócio: definir datas antes de salvar
            produto.CriadoEm = DateTime.UtcNow;
            produto.AtualizadoEm = DateTime.UtcNow;
            return await _produtoRepository.AddAsync(produto);
        }

        public async Task<bool> UpdateProductAsync(int id, ProdutoModel produtoAtualizado)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null)
            {
                return false; // Indica que o produto não foi encontrado
            }

            // Mapeia as propriedades atualizadas
            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.PrecoCusto = produtoAtualizado.PrecoCusto;
            produtoExistente.PrecoVenda = produtoAtualizado.PrecoVenda;
            produtoExistente.FornecedorId = produtoAtualizado.FornecedorId;
            
            // Regra de negócio: atualizar a data
            produtoExistente.AtualizadoEm = DateTime.UtcNow;

            await _produtoRepository.UpdateAsync(produtoExistente);
            return true;
        }
    }
}
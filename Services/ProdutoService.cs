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

        public async Task<IEnumerable<ProdutoModel>> GetAllProductsAsync(bool includeInactive = false)
        {
            return await _produtoRepository.GetAllAsync(includeInactive);
        }

        public async Task<SiteBrecho.Dtos.PagedResult<ProdutoModel>> GetAllProductsPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _produtoRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new SiteBrecho.Dtos.PagedResult<ProdutoModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<ProdutoModel?> GetProductByIdAsync(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<ProdutoModel> CreateProductAsync(ProdutoModel produto)
        {
            produto.CriadoEm = DateTime.UtcNow;
            produto.AtualizadoEm = DateTime.UtcNow;
            return await _produtoRepository.AddAsync(produto);
        }

        public async Task<bool> UpdateProductAsync(int id, ProdutoModel produtoAtualizado)
        {
            var produtoExistente = await _produtoRepository.GetByIdAsync(id);
            if (produtoExistente == null)
            {
                return false;
            }

            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.PrecoCusto = produtoAtualizado.PrecoCusto;
            produtoExistente.PrecoVenda = produtoAtualizado.PrecoVenda;
            produtoExistente.FornecedorId = produtoAtualizado.FornecedorId;

            produtoExistente.AtualizadoEm = DateTime.UtcNow;

            await _produtoRepository.UpdateAsync(produtoExistente);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                return false;
            }

            // Soft delete: marca como excluído
            produto.Excluido = true;
            await _produtoRepository.UpdateAsync(produto);
            return true;
        }

        public async Task<bool> ActivateProductAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null || produto.Excluido)
            {
                return false;
            }

            produto.Ativo = true;
            await _produtoRepository.UpdateAsync(produto);
            return true;
        }

        public async Task<bool> DeactivateProductAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null || produto.Excluido)
            {
                return false;
            }

            produto.Ativo = false;
            await _produtoRepository.UpdateAsync(produto);
            return true;
        }
    }
}
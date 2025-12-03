using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class ProdutoSkuService : IProdutoSkuService
    {
        private readonly IProdutoSkuRepository _produtoSkuRepository;

        public ProdutoSkuService(IProdutoSkuRepository produtoSkuRepository)
        {
            _produtoSkuRepository = produtoSkuRepository;
        }

        public async Task<IEnumerable<ProdutoSkuModel>> GetAllProductSkuAsync(bool includeInactive = false)
        {
            return await _produtoSkuRepository.GetAllAsync(includeInactive);
        }

        public async Task<SiteBrecho.Dtos.PagedResult<ProdutoSkuModel>> GetAllProductSkuPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _produtoSkuRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new SiteBrecho.Dtos.PagedResult<ProdutoSkuModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<ProdutoSkuModel?> GetProductSkuByIdAsync(int id)
        {
            return await _produtoSkuRepository.GetByIdAsync(id);
        }

        public async Task<ProdutoSkuModel> CreateProductSkuAsync(ProdutoSkuModel produtoSku)
        {
            produtoSku.CriadoEm = DateTime.UtcNow;
            produtoSku.AtualizadoEm = DateTime.UtcNow;
            return await _produtoSkuRepository.AddAsync(produtoSku);
        }

        public async Task<bool> UpdateProductSkuAsync(int id, ProdutoSkuModel produtoSkuAtualizado)
        {
            var produtoSkuExistente = await _produtoSkuRepository.GetByIdAsync(id);
            if (produtoSkuExistente == null)
            {
                return false;
            }

            produtoSkuExistente.Descricao = produtoSkuAtualizado.Descricao;
            produtoSkuExistente.PrecoVenda = produtoSkuAtualizado.PrecoVenda;
            produtoSkuExistente.ProdutoVariationId1 = produtoSkuAtualizado.ProdutoVariationId1;
            produtoSkuExistente.ProdutoVariationId2 = produtoSkuAtualizado.ProdutoVariationId2;

            produtoSkuExistente.AtualizadoEm = DateTime.UtcNow;

            await _produtoSkuRepository.UpdateAsync(produtoSkuExistente);
            return true;
        }

        public async Task<bool> DeleteProductSkuAsync(int id)
        {
            var produtoSku = await _produtoSkuRepository.GetByIdAsync(id);
            if (produtoSku == null)
            {
                return false;
            }

            produtoSku.Excluido = true;
            await _produtoSkuRepository.UpdateAsync(produtoSku);
            return true;
        }

        public async Task<bool> ActivateProductSkuAsync(int id)
        {
            var produtoSku = await _produtoSkuRepository.GetByIdAsync(id);
            if (produtoSku == null || produtoSku.Excluido)
            {
                return false;
            }

            produtoSku.Ativo = true;
            await _produtoSkuRepository.UpdateAsync(produtoSku);
            return true;
        }

        public async Task<bool> DeactivateProductSkuAsync(int id)
        {
            var produtoSku = await _produtoSkuRepository.GetByIdAsync(id);
            if (produtoSku == null || produtoSku.Excluido)
            {
                return false;
            }

            produtoSku.Ativo = false;
            await _produtoSkuRepository.UpdateAsync(produtoSku);
            return true;
        }
    }
}
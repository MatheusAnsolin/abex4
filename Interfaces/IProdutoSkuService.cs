using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoSkuService
    {
        Task<IEnumerable<ProdutoSkuModel>> GetAllProductSkuAsync(bool includeInactive = false);
        Task<PagedResult<ProdutoSkuModel>> GetAllProductSkuPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoSkuModel?> GetProductSkuByIdAsync(int id);
        Task<ProdutoSkuModel> CreateProductSkuAsync(ProdutoSkuModel produtoSku);
        Task<bool> UpdateProductSkuAsync(int id, ProdutoSkuModel produtoSku);
        Task<bool> DeleteProductSkuAsync(int id);
        Task<bool> ActivateProductSkuAsync(int id);
        Task<bool> DeactivateProductSkuAsync(int id);
    }
}
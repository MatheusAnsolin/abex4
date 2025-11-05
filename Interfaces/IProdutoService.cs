using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> GetAllProductsAsync(bool includeInactive = false);
        Task<PagedResult<ProdutoModel>> GetAllProductsPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoModel?> GetProductByIdAsync(int id);
        Task<ProdutoModel> CreateProductAsync(ProdutoModel produto);
        Task<bool> UpdateProductAsync(int id, ProdutoModel produto);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> ActivateProductAsync(int id);
        Task<bool> DeactivateProductAsync(int id);
    }
}
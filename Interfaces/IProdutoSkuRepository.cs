using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoSkuRepository
    {
        Task<IEnumerable<ProdutoSkuModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<ProdutoSkuModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoSkuModel?> GetByIdAsync(int id);
        Task<ProdutoSkuModel> AddAsync(ProdutoSkuModel produtoSku);
        Task UpdateAsync(ProdutoSkuModel produtoSku);
        Task DeleteAsync(int id);
    }
}
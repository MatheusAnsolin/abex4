using SiteBrecho.Models;
using SiteBrecho.Dtos;

namespace SiteBrecho.Interfaces
{
    public interface IEstoqueService
    {
        Task<IEnumerable<EstoqueModel>> GetAllStocksAsync(bool includeInactive = false);
        Task<PagedResult<EstoqueModel>> GetAllStocksPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<EstoqueModel?> GetStockByIdAsync(int id);
        Task<EstoqueModel?> GetStockByProdutoSkuIdAsync(int produtoSkuId);
        Task<EstoqueModel> CreateStockAsync(CreateEstoqueDto dto);
        Task<bool> UpdateStockAsync(int id, UpdateEstoqueDto dto);
        Task<bool> UpdateStockBySkuIdAsync(int produtoSkuId, UpdateEstoqueDto dto);
        Task<bool> DeleteStockAsync(int id);
        Task<bool> ActivateStockAsync(int id);
        Task<bool> DeactivateStockAsync(int id);
    }
}
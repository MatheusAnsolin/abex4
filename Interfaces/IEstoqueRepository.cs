using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<EstoqueModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<EstoqueModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<EstoqueModel?> GetByIdAsync(int id);
        Task<EstoqueModel?> GetByProdutoSkuIdAsync(int produtoSkuId);
        Task<EstoqueModel> CreateAsync(EstoqueModel estoque);
        Task UpdateAsync(EstoqueModel estoque);
        Task<bool> DeleteAsync(int id);
    }
}

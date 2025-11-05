using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<ProdutoModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoModel?> GetByIdAsync(int id);
        Task<ProdutoModel> AddAsync(ProdutoModel produto);
        Task UpdateAsync(ProdutoModel produto);
        Task DeleteAsync(int id);
    }
}
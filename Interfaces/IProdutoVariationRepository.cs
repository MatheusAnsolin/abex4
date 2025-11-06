using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoVariationRepository
    {
        Task<IEnumerable<ProdutoVariationModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<ProdutoVariationModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoVariationModel?> GetByIdAsync(int id);
        Task<ProdutoVariationModel> AddAsync(ProdutoVariationModel variation);
        Task UpdateAsync(ProdutoVariationModel variation);
        Task DeleteAsync(int id);
    }
}


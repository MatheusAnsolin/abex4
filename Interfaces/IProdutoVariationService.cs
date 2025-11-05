using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoVariationService
    {
        Task<IEnumerable<ProdutoVariationModel>> GetAllVariationsAsync(bool includeInactive = false);
        Task<PagedResult<ProdutoVariationModel>> GetAllVariationsPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<ProdutoVariationModel?> GetVariationByIdAsync(int id);
        Task<ProdutoVariationModel> CreateVariationAsync(ProdutoVariationModel variation);
        Task<bool> UpdateVariationAsync(int id, ProdutoVariationModel variation);
        Task<bool> DeleteVariationAsync(int id);
        Task<bool> ActivateVariationAsync(int id);
        Task<bool> DeactivateVariationAsync(int id);
    }
}


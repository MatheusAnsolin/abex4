using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IVendaRepository
    {
        Task<VendaModel> CreateAsync(VendaModel venda);
        Task<IEnumerable<VendaModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<VendaModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<VendaModel?> GetByIdAsync(int id);
    }
}
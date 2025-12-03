using SiteBrecho.Models;
using SiteBrecho.Dtos;

namespace SiteBrecho.Interfaces
{
    public interface IVendaService
    {
        Task<VendaModel> CriarVendaAsync(CreateVendaDto vendaDto);
        Task<IEnumerable<VendaModel>> GetAllVendasAsync(bool includeInactive = false);
        Task<PagedResult<VendaModel>> GetAllVendasPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<VendaModel?> GetVendaByIdAsync(int id);
    }
}
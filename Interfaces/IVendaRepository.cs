using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IVendaRepository
    {
        Task<VendaModel> CreateAsync(VendaModel venda);
    }
}
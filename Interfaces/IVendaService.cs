using SiteBrecho.Models;
using SiteBrecho.Dtos;

namespace SiteBrecho.Interfaces
{
    public interface IVendaService
    {
        Task<VendaModel> CriarVendaAsync(CreateVendaDto vendaDto);
    }
}
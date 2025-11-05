using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorModel>> GetAllSupplierAsync(bool includeInactive = false);
        Task<PagedResult<FornecedorModel>> GetAllSupplierPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<FornecedorModel?> GetSupplierByIdAsync(int id);
        Task<FornecedorModel> CreateSupplierAsync(FornecedorModel fornecedor);
        Task<bool> UpdateSupplierAsync(int id, FornecedorModel fornecedor);
        Task<bool> DeleteSupplierAsync(int id);
        Task<bool> ActivateSupplierAsync(int id);
        Task<bool> DeactivateSupplierAsync(int id);
    }
}
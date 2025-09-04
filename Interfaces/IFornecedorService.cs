using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorModel>> GetAllSupplierAsync();
        Task<FornecedorModel?> GetSupplierByIdAsync(int id);
        Task<FornecedorModel> CreateSupplierAsync(FornecedorModel fornecedor);
        Task<bool> UpdateSupplierAsync(FornecedorModel fornecedor);
    }
}
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorModel>> GetAllAsync();
        Task<FornecedorModel?> GetByIdAsync(int id);
        Task<FornecedorModel> CreateAsync(FornecedorModel fornecedor);
        Task UpdateAsync(FornecedorModel fornecedor);
    }
}

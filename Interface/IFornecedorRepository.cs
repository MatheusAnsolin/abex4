using SiteBrecho.Repositories;

namespace SiteBrecho.Repositories
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorModel>> GetAllAsync();
        Task<FornecedorModel> GetByIdAsync(int id);
        Task<FornecedorModel> CreateAsync(FornecedorModel fornecedor);
        Task UpdateAsync(FornecedorModel fornecedor);
        Task DeleteAsync(int id);
    }
}

using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<IEnumerable<FornecedorModel>> GetAllAsync(bool includeInactive = false);
        Task<(IEnumerable<FornecedorModel> Items, int TotalCount)> GetAllPagedAsync(PaginationParameters parameters, bool includeInactive = false);
        Task<FornecedorModel?> GetByIdAsync(int id);
        Task<FornecedorModel> CreateAsync(FornecedorModel fornecedor);
        Task UpdateAsync(FornecedorModel fornecedor);
        Task DeleteAsync(int id);
    }
}

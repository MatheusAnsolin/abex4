using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<ProdutoModel>> GetAllAsync();
        Task<ProdutoModel?> GetByIdAsync(int id);
        Task<ProdutoModel> AddAsync(ProdutoModel produto);
        Task UpdateAsync(ProdutoModel produto);
    }
}
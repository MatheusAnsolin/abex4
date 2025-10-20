using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<IEnumerable<EstoqueModel>> GetAllAsync();
        Task<EstoqueModel?> GetByIdAsync(int id);
        Task<EstoqueModel?> GetByProdutoIdAsync(int produtoId);
        Task<EstoqueModel> CreateAsync(EstoqueModel estoque);
        Task UpdateAsync(EstoqueModel estoque);
        Task<bool> DeleteAsync(int id);
    }
}

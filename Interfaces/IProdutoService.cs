using SiteBrecho.Models;

namespace SiteBrecho.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoModel>> GetAllProductsAsync();
        Task<ProdutoModel?> GetProductByIdAsync(int id);
        Task<ProdutoModel> CreateProductAsync(ProdutoModel produto);
        Task<bool> UpdateProductAsync(int id, ProdutoModel produto);
    }
}
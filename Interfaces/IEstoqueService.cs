using SiteBrecho.Models;
using SiteBrecho.Dtos;  

namespace SiteBrecho.Interfaces
{
    public interface IEstoqueService
    {
    Task<IEnumerable<EstoqueModel>> GetAllStocksAsync();
    Task<EstoqueModel?> GetStockByIdAsync(int id);
    Task<EstoqueModel> CreateStockAsync(CreateUpdateEstoqueDto dto);
    Task<bool> UpdateStockAsync(int id, CreateUpdateEstoqueDto dto);
    Task<bool> DeleteStockAsync(int id);
    }
}
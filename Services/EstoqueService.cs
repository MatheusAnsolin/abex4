using SiteBrecho.Models;
using SiteBrecho.Interfaces;
using SiteBrecho.Dtos;

namespace SiteBrecho.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<IEnumerable<EstoqueModel>> GetAllStocksAsync()
        {
            return await _estoqueRepository.GetAllAsync();
        }

        public async Task<EstoqueModel?> GetStockByIdAsync(int id)
        {
            return await _estoqueRepository.GetByIdAsync(id);
        }

        public async Task<EstoqueModel> CreateStockAsync(CreateUpdateEstoqueDto dto)
        {
            var estoque = new EstoqueModel
            {
                ProdutoId = dto.ProdutoId,
                QuantidadeAtual = dto.QuantidadeAtual
            };
            return await _estoqueRepository.CreateAsync(estoque);
        }

        public async Task<bool> UpdateStockAsync(int id, CreateUpdateEstoqueDto dto)
        {
            var existing = await _estoqueRepository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.ProdutoId = dto.ProdutoId;
            existing.QuantidadeAtual = dto.QuantidadeAtual;
            await _estoqueRepository.UpdateAsync(existing);
            return true;
        }


        public async Task<bool> DeleteStockAsync(int id)
        {
            return await _estoqueRepository.DeleteAsync(id);
        }
    }
}
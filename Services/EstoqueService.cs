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

        public async Task<IEnumerable<EstoqueModel>> GetAllStocksAsync(bool includeInactive = false)
        {
            return await _estoqueRepository.GetAllAsync(includeInactive);
        }

        public async Task<PagedResult<EstoqueModel>> GetAllStocksPagedAsync(PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _estoqueRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new PagedResult<EstoqueModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<EstoqueModel?> GetStockByIdAsync(int id)
        {
            return await _estoqueRepository.GetByIdAsync(id);
        }

        public async Task<EstoqueModel?> GetStockByProdutoSkuIdAsync(int produtoSkuId)
        {
            return await _estoqueRepository.GetByProdutoSkuIdAsync(produtoSkuId);
        }

        public async Task<EstoqueModel> CreateStockAsync(CreateUpdateEstoqueDto dto)
        {
            var estoque = new EstoqueModel
            {
                ProdutoSkuId = dto.ProdutoSkuId,
                QuantidadeAtual = dto.QuantidadeAtual,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            };
            return await _estoqueRepository.CreateAsync(estoque);
        }

        public async Task<bool> UpdateStockAsync(int id, CreateUpdateEstoqueDto dto)
        {
            var existing = await _estoqueRepository.GetByIdAsync(id);
            if (existing == null) return false;

            existing.ProdutoSkuId = dto.ProdutoSkuId;
            existing.QuantidadeAtual = dto.QuantidadeAtual;
            existing.AtualizadoEm = DateTime.UtcNow;
            await _estoqueRepository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteStockAsync(int id)
        {
            var estoque = await _estoqueRepository.GetByIdAsync(id);
            if (estoque == null) return false;

            estoque.Excluido = true;
            await _estoqueRepository.UpdateAsync(estoque);
            return true;
        }

        public async Task<bool> ActivateStockAsync(int id)
        {
            var estoque = await _estoqueRepository.GetByIdAsync(id);
            if (estoque == null || estoque.Excluido) return false;

            estoque.Ativo = true;
            await _estoqueRepository.UpdateAsync(estoque);
            return true;
        }

        public async Task<bool> DeactivateStockAsync(int id)
        {
            var estoque = await _estoqueRepository.GetByIdAsync(id);
            if (estoque == null || estoque.Excluido) return false;

            estoque.Ativo = false;
            await _estoqueRepository.UpdateAsync(estoque);
            return true;
        }
    }
}
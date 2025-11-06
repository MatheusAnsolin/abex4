using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class ProdutoVariationService : IProdutoVariationService
    {
        private readonly IProdutoVariationRepository _variationRepository;

        public ProdutoVariationService(IProdutoVariationRepository variationRepository)
        {
            _variationRepository = variationRepository;
        }

        public async Task<IEnumerable<ProdutoVariationModel>> GetAllVariationsAsync(bool includeInactive = false)
        {
            return await _variationRepository.GetAllAsync(includeInactive);
        }

        public async Task<SiteBrecho.Dtos.PagedResult<ProdutoVariationModel>> GetAllVariationsPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _variationRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new SiteBrecho.Dtos.PagedResult<ProdutoVariationModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<ProdutoVariationModel?> GetVariationByIdAsync(int id)
        {
            return await _variationRepository.GetByIdAsync(id);
        }

        public async Task<ProdutoVariationModel> CreateVariationAsync(ProdutoVariationModel variation)
        {
            variation.CriadoEm = DateTime.UtcNow;
            variation.AtualizadoEm = DateTime.UtcNow;
            return await _variationRepository.AddAsync(variation);
        }

        public async Task<bool> UpdateVariationAsync(int id, ProdutoVariationModel variationAtualizada)
        {
            var variationExistente = await _variationRepository.GetByIdAsync(id);
            if (variationExistente == null)
            {
                return false;
            }

            variationExistente.Nome = variationAtualizada.Nome;
            variationExistente.Descricao = variationAtualizada.Descricao;
            variationExistente.AtualizadoEm = DateTime.UtcNow;

            await _variationRepository.UpdateAsync(variationExistente);
            return true;
        }

        public async Task<bool> DeleteVariationAsync(int id)
        {
            var variation = await _variationRepository.GetByIdAsync(id);
            if (variation == null)
            {
                return false;
            }

            variation.Excluido = true;
            await _variationRepository.UpdateAsync(variation);
            return true;
        }

        public async Task<bool> ActivateVariationAsync(int id)
        {
            var variation = await _variationRepository.GetByIdAsync(id);
            if (variation == null || variation.Excluido)
            {
                return false;
            }

            variation.Ativo = true;
            await _variationRepository.UpdateAsync(variation);
            return true;
        }

        public async Task<bool> DeactivateVariationAsync(int id)
        {
            var variation = await _variationRepository.GetByIdAsync(id);
            if (variation == null || variation.Excluido)
            {
                return false;
            }

            variation.Ativo = false;
            await _variationRepository.UpdateAsync(variation);
            return true;
        }
    }
}


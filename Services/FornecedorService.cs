using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<IEnumerable<FornecedorModel>> GetAllSupplierAsync(bool includeInactive = false)
        {
            return await _fornecedorRepository.GetAllAsync(includeInactive);
        }

        public async Task<SiteBrecho.Dtos.PagedResult<FornecedorModel>> GetAllSupplierPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var (items, totalCount) = await _fornecedorRepository.GetAllPagedAsync(parameters, includeInactive);

            var totalPages = (int)Math.Ceiling(totalCount / (double)parameters.PageSize);

            return new SiteBrecho.Dtos.PagedResult<FornecedorModel>
            {
                Data = items,
                PageNumber = parameters.PageNumber,
                PageSize = parameters.PageSize,
                TotalRecords = totalCount,
                TotalPages = totalPages
            };
        }

        public async Task<FornecedorModel?> GetSupplierByIdAsync(int id)
        {
            return await _fornecedorRepository.GetByIdAsync(id);
        }

        public async Task<FornecedorModel> CreateSupplierAsync(FornecedorModel fornecedor)
        {
            if (string.IsNullOrWhiteSpace(fornecedor.Nome) || string.IsNullOrWhiteSpace(fornecedor.CnpjCpf))
            {
                throw new ArgumentException("Nome e CNPJ do fornecedor são obrigatórios.");
            }

            return await _fornecedorRepository.CreateAsync(fornecedor);
        }

        public async Task<bool> UpdateSupplierAsync(int id, FornecedorModel fornecedorAtualizado)
        {
            var fornecedorExistente = await _fornecedorRepository.GetByIdAsync(id);
            if (fornecedorExistente == null)
            {
                return false;
            }

            fornecedorExistente.Nome = fornecedorAtualizado.Nome;
            fornecedorExistente.Email = fornecedorAtualizado.Email;
            fornecedorExistente.Endereco = fornecedorAtualizado.Endereco;
            fornecedorExistente.Telefone = fornecedorAtualizado.Telefone;

            await _fornecedorRepository.UpdateAsync(fornecedorExistente);
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            if (fornecedor == null)
            {
                return false;
            }

            // Soft delete: marca como excluído
            fornecedor.Excluido = true;
            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task<bool> ActivateSupplierAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            if (fornecedor == null || fornecedor.Excluido)
            {
                return false;
            }

            fornecedor.Ativo = true;
            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }

        public async Task<bool> DeactivateSupplierAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            if (fornecedor == null || fornecedor.Excluido)
            {
                return false;
            }

            fornecedor.Ativo = false;
            await _fornecedorRepository.UpdateAsync(fornecedor);
            return true;
        }
    }
}
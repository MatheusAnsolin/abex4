using SiteBrecho.Models;
using SiteBrecho.Repositories;

namespace SiteBrecho.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Task<IEnumerable<FornecedorModel>> GetAllSupplierAsync()
        {
            return _fornecedorRepository.GetAllAsync();
        }

        public Task<FornecedorModel?> GetSupplierByIdAsync(int id)
        {
            return _fornecedorRepository.GetByIdAsync(id);
        }

        public Task<FornecedorModel> CreateSupplierAsync(FornecedorModel fornecedor)
        {
            if (string.IsNullOrWhiteSpace(fornecedor.Nome) || string.IsNullOrWhiteSpace(fornecedor.CNPJ))
            {
                throw new ArgumentException("Nome e CNPJ do fornecedor são obrigatórios.");
            }

            return _fornecedorRepository.CreateeAsync(novoFornecedor);
        }

        public Task<bool> UpdateSupplierAsync(FornecedorModel fornecedorAtualizado)
        {
            if (fornecedorAtualizado.Id <= 0)
            {
                throw new ArgumentException("ID do fornecedor inválido.");
            }

            return _fornecedorRepository.UpdateAsync(fornecedorAtualizado);
        }
    }
}
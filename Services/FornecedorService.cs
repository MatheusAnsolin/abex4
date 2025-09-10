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

        public async Task<IEnumerable<FornecedorModel>> GetAllSupplierAsync()
        {
            return await _fornecedorRepository.GetAllAsync();
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
    }
}
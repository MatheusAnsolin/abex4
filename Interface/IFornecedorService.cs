using SiteBrecho.Models;

namespace SiteBrecho.Services
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorModel>> ObterFornecedorAsync();
        Task<Fornecedor> ObterIdFornecedorAsync(int id);
        Task<Fornecedor> AdicionarFornecedorAsync(FornecedorModel fornecedor);
        Task<Fornecedor> AtualizarFornecedorAsync(FornecedorModel fornecedor);
    }
}
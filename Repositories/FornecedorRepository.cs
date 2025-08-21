using Microsoft.EntityFrameworkCore;
using SiteBrecho.Models;
using SiteBrecho.Data;

namespace SiteBrecho.Repositories
{

    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext __context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            __context = context;
        }

        public async Task<IEnumerable<FornecedorModel>> GetAllAsync()
        {
            return await __context.Fornecedores.ToListAsync();
        }

        public async Task<FornecedorModel> GetByIdAsync(int id)
        {
            return await __context.Fornecedores.FindAsync(id);
        }

        public async Task<FornecedorModel> CreateAsync(FornecedorModel fornecedor)
        {
            forncedor.CriadoEm = DateTime.UtcNow;
            __context.Fornecedores.Add(fornecedor);
            await __context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task UpdateAsync(FornecedorModel fornecedor)
        {
            __context.Entry(fornecedor).State = EntityState.Modified;
            await __context.SaveChangesAsync();
        }
    }
}
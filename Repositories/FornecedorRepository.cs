using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{

    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FornecedorModel>> GetAllAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<FornecedorModel?> GetByIdAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<FornecedorModel> CreateAsync(FornecedorModel fornecedor)
        {
            fornecedor.CriadoEm = DateTime.UtcNow;
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        public async Task UpdateAsync(FornecedorModel fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
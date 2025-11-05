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

        public async Task<IEnumerable<FornecedorModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.Fornecedores.AsQueryable();

            // Sempre remove os excluídos
            query = query.Where(f => !f.Excluido);

            // Remove inativos se não for includeInactive
            if (!includeInactive)
            {
                query = query.Where(f => f.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<FornecedorModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.Fornecedores.AsQueryable();

            // Sempre remove os excluídos
            query = query.Where(f => !f.Excluido);

            // Remove inativos se não for includeInactive
            if (!includeInactive)
            {
                query = query.Where(f => f.Ativo);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
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

        public async Task DeleteAsync(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
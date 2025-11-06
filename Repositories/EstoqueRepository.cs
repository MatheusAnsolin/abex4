using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly AppDbContext _context;

        public EstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstoqueModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.Estoques.AsQueryable();

            query = query.Where(e => !e.Excluido);

            if (!includeInactive)
            {
                query = query.Where(e => e.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<EstoqueModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.Estoques.AsQueryable();

            query = query.Where(e => !e.Excluido);

            if (!includeInactive)
            {
                query = query.Where(e => e.Ativo);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<EstoqueModel?> GetByIdAsync(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task<EstoqueModel?> GetByProdutoSkuIdAsync(int produtoSkuId)
        {
            return await _context.Estoques.FirstOrDefaultAsync(e => e.ProdutoSkuId == produtoSkuId);
        }

        public async Task<EstoqueModel> CreateAsync(EstoqueModel estoque)
        {
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();
            return estoque;
        }

        public async Task UpdateAsync(EstoqueModel estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null)
                return false;

            _context.Estoques.Remove(estoque);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
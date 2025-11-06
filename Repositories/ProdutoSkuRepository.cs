using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{
    public class ProdutoSkuRepository : IProdutoSkuRepository
    {
        private readonly AppDbContext _context;

        public ProdutoSkuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoSkuModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.ProdutoSkus.AsQueryable();

            query = query.Where(ps => !ps.Excluido);

            if (!includeInactive)
            {
                query = query.Where(ps => ps.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<ProdutoSkuModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.ProdutoSkus.AsQueryable();

            query = query.Where(ps => !ps.Excluido);

            if (!includeInactive)
            {
                query = query.Where(ps => ps.Ativo);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<ProdutoSkuModel?> GetByIdAsync(int id)
        {
            return await _context.ProdutoSkus.FindAsync(id);
        }

        public async Task<ProdutoSkuModel> AddAsync(ProdutoSkuModel produtoSku)
        {
            _context.ProdutoSkus.Add(produtoSku);
            await _context.SaveChangesAsync();
            return produtoSku;
        }

        public async Task UpdateAsync(ProdutoSkuModel produtoSku)
        {
            _context.Entry(produtoSku).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produtoSku = await _context.ProdutoSkus.FindAsync(id);
            if (produtoSku != null)
            {
                _context.ProdutoSkus.Remove(produtoSku);
                await _context.SaveChangesAsync();
            }
        }
    }
}
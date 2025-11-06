using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{
    public class ProdutoVariationRepository : IProdutoVariationRepository
    {
        private readonly AppDbContext _context;

        public ProdutoVariationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoVariationModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.ProdutoVariations.AsQueryable();

            query = query.Where(v => !v.Excluido);

            if (!includeInactive)
            {
                query = query.Where(v => v.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<ProdutoVariationModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.ProdutoVariations.AsQueryable();

            query = query.Where(v => !v.Excluido);

            if (!includeInactive)
            {
                query = query.Where(v => v.Ativo);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<ProdutoVariationModel?> GetByIdAsync(int id)
        {
            return await _context.ProdutoVariations.FindAsync(id);
        }

        public async Task<ProdutoVariationModel> AddAsync(ProdutoVariationModel variation)
        {
            _context.ProdutoVariations.Add(variation);
            await _context.SaveChangesAsync();
            return variation;
        }

        public async Task UpdateAsync(ProdutoVariationModel variation)
        {
            _context.Entry(variation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var variation = await _context.ProdutoVariations.FindAsync(id);
            if (variation != null)
            {
                _context.ProdutoVariations.Remove(variation);
                await _context.SaveChangesAsync();
            }
        }
    }
}


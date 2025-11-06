using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.Produtos.AsQueryable();

            query = query.Where(p => !p.Excluido);

            if (!includeInactive)
            {
                query = query.Where(p => p.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<ProdutoModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.Produtos.AsQueryable();

            query = query.Where(p => !p.Excluido);

            if (!includeInactive)
            {
                query = query.Where(p => p.Ativo);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<ProdutoModel?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<ProdutoModel> AddAsync(ProdutoModel produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task UpdateAsync(ProdutoModel produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
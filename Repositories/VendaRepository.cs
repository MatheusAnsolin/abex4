using Microsoft.EntityFrameworkCore;
using SiteBrecho.Data;
using SiteBrecho.Interfaces;
using SiteBrecho.Models;

namespace SiteBrecho.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VendaModel> CreateAsync(VendaModel venda)
        {
            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();
            return venda;
        }

        public async Task<IEnumerable<VendaModel>> GetAllAsync(bool includeInactive = false)
        {
            var query = _context.Vendas.Include(v => v.Itens).AsQueryable();

            query = query.Where(v => !v.Excluido);

            if (!includeInactive)
            {
                query = query.Where(v => v.Ativo);
            }

            return await query.ToListAsync();
        }

        public async Task<(IEnumerable<VendaModel> Items, int TotalCount)> GetAllPagedAsync(SiteBrecho.Dtos.PaginationParameters parameters, bool includeInactive = false)
        {
            var query = _context.Vendas.Include(v => v.Itens).AsQueryable();

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

        public async Task<VendaModel?> GetByIdAsync(int id)
        {
            return await _context.Vendas.Include(v => v.Itens).FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
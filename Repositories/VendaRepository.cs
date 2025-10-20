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
    }
}
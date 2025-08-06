using Microsoft.EntityFrameworkCore;
using SiteBrecho.Models; 
namespace SiteBrecho.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<ProdutoModel> Produtos { get; set; }  // exemplo
    }
}
namespace SiteBrecho.Data;
using Microsoft.EntityFrameworkCore;
using SiteBrecho.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProdutoModel> Produtos { get; set; }
}

namespace SiteBrecho.Data;
using Microsoft.EntityFrameworkCore;
using SiteBrecho.Models; 
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<FornecedorModel> Fornecedores { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<AdministradorModel> Administradores { get; set; }
    public DbSet<MovimentacaoModel> Movimentacoes { get; set; }
    public DbSet<EstoqueModel> Estoques { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstoqueModel>()
            .HasOne(e => e.Produto)
            .WithOne(p => p.Estoque)
            .HasForeignKey<EstoqueModel>(e => e.ProdutoId);

        // seed 
        modelBuilder.Entity<AdministradorModel>().HasData(new AdministradorModel
        {
            Id = 1,
            Nome = "Admin",
            Email = "admin@admin.com",
            SenhaHash = "123456" 
        });
    }
}

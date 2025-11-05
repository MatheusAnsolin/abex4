namespace SiteBrecho.Data;
using Microsoft.EntityFrameworkCore;
using SiteBrecho.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<FornecedorModel> Fornecedores { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<ProdutoSkuModel> ProdutoSkus { get; set; }
    public DbSet<ProdutoVariationModel> ProdutoVariations { get; set; }
    public DbSet<AdministradorModel> Administradores { get; set; }
    public DbSet<MovimentacaoModel> Movimentacoes { get; set; }
    public DbSet<EstoqueModel> Estoques { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstoqueModel>()
            .HasOne(e => e.ProdutoSku)
            .WithOne()
            .HasForeignKey<EstoqueModel>(e => e.ProdutoSkuId);

        // seed 
        modelBuilder.Entity<AdministradorModel>().HasData(new AdministradorModel
        {
            Id = 1,
            Nome = "Admin",
            Email = "admin@admin.com",
            SenhaHash = "123456"
        });


        var seedDate = new DateTime(2025, 9, 2, 20, 0, 0, DateTimeKind.Utc);
        modelBuilder.Entity<ProdutoModel>().HasData(
            new ProdutoModel
            {
                Id = -1,
                Nome = "Jaqueta de Couro Vintage",
                Descricao = "Jaqueta de couro preta, estilo motociclista. Em ótimo estado.",
                PrecoCusto = 70.00M,
                PrecoVenda = 180.50M,
                FornecedorId = null,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new ProdutoModel
            {
                Id = -2,
                Nome = "Calça Jeans Reta Anos 90",
                Descricao = "Calça jeans de cintura alta, lavagem clara. Perfeita para um look retrô.",
                PrecoCusto = 25.00M,
                PrecoVenda = 79.90M,
                FornecedorId = 1,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new ProdutoModel
            {
                Id = -3,
                Nome = "Vestido Floral Longo",
                Descricao = null,
                PrecoCusto = 35.50M,
                PrecoVenda = 95.00M,
                FornecedorId = 1,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new ProdutoModel
            {
                Id = -4,
                Nome = "Bolsa de Couro Caramelo",
                Descricao = "Bolsa de ombro em couro legítimo, com detalhes em metal dourado.",
                PrecoCusto = 50.00M,
                PrecoVenda = 130.00M,
                FornecedorId = 2,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            }
        );
    }
}

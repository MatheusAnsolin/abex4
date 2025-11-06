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
    public DbSet<VendaModel> Vendas { get; set; }
    public DbSet<VendaItemModel> VendaItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EstoqueModel>()
            .HasOne(e => e.ProdutoSku)
            .WithOne()
            .HasForeignKey<EstoqueModel>(e => e.ProdutoSkuId);

        var seedDate = new DateTime(2025, 9, 2, 20, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<AdministradorModel>().HasData(new AdministradorModel
        {
            Id = 1,
            Nome = "Admin",
            Email = "admin@admin.com",
            SenhaHash = "123456"
        });

        modelBuilder.Entity<FornecedorModel>().HasData(
            new FornecedorModel
            {
                Id = 1,
                Nome = "Brechó da Vila",
                CnpjCpf = "12.345.678/0001-90",
                Email = "contato@brechodavila.com.br",
                Telefone = "(11) 98765-4321",
                Endereco = "Rua das Flores, 123 - São Paulo/SP",
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new FornecedorModel
            {
                Id = 2,
                Nome = "Vintage Store",
                CnpjCpf = "98.765.432/0001-10",
                Email = "vendas@vintagestore.com.br",
                Telefone = "(11) 91234-5678",
                Endereco = "Av. Paulista, 456 - São Paulo/SP",
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            }
        );

        modelBuilder.Entity<ProdutoVariationModel>().HasData(
            new ProdutoVariationModel { Id = 1, Nome = "Tamanho P", Descricao = "Pequeno", Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoVariationModel { Id = 2, Nome = "Tamanho M", Descricao = "Médio", Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoVariationModel { Id = 3, Nome = "Tamanho G", Descricao = "Grande", Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoVariationModel { Id = 4, Nome = "Cor Preta", Descricao = null, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoVariationModel { Id = 5, Nome = "Cor Azul", Descricao = null, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoVariationModel { Id = 6, Nome = "Cor Vermelha", Descricao = null, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate }
        );

        modelBuilder.Entity<ProdutoModel>().HasData(
            new ProdutoModel
            {
                Id = 1,
                Nome = "Jaqueta de Couro Vintage",
                Descricao = "Jaqueta de couro estilo motociclista. Em ótimo estado.",
                PrecoCusto = 70.00M,
                PrecoVenda = 180.50M,
                FornecedorId = 1,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new ProdutoModel
            {
                Id = 2,
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
                Id = 3,
                Nome = "Vestido Floral Longo",
                Descricao = "Vestido longo com estampa floral, ideal para o verão.",
                PrecoCusto = 35.50M,
                PrecoVenda = 95.00M,
                FornecedorId = 2,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new ProdutoModel
            {
                Id = 4,
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

        modelBuilder.Entity<ProdutoSkuModel>().HasData(
            new ProdutoSkuModel { Id = 1, ProdutoId = 1, ProdutoVariationId1 = 2, ProdutoVariationId2 = 4, Descricao = "Jaqueta M Preta", PrecoVenda = 180.50M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 2, ProdutoId = 1, ProdutoVariationId1 = 3, ProdutoVariationId2 = 4, Descricao = "Jaqueta G Preta", PrecoVenda = 185.00M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 3, ProdutoId = 2, ProdutoVariationId1 = 1, ProdutoVariationId2 = 5, Descricao = "Calça Jeans P Azul", PrecoVenda = 79.90M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 4, ProdutoId = 2, ProdutoVariationId1 = 2, ProdutoVariationId2 = 5, Descricao = "Calça Jeans M Azul", PrecoVenda = 79.90M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 5, ProdutoId = 3, ProdutoVariationId1 = 1, ProdutoVariationId2 = 6, Descricao = "Vestido P Vermelho", PrecoVenda = 95.00M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 6, ProdutoId = 3, ProdutoVariationId1 = 2, ProdutoVariationId2 = 6, Descricao = "Vestido M Vermelho", PrecoVenda = 95.00M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new ProdutoSkuModel { Id = 7, ProdutoId = 4, ProdutoVariationId1 = 2, ProdutoVariationId2 = null, Descricao = "Bolsa Tamanho M", PrecoVenda = 130.00M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate }
        );

        modelBuilder.Entity<EstoqueModel>().HasData(
            new EstoqueModel { ProdutoSkuId = 1, QuantidadeAtual = 5, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 2, QuantidadeAtual = 3, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 3, QuantidadeAtual = 8, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 4, QuantidadeAtual = 10, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 5, QuantidadeAtual = 4, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 6, QuantidadeAtual = 6, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new EstoqueModel { ProdutoSkuId = 7, QuantidadeAtual = 2, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate }
        );

        modelBuilder.Entity<VendaModel>().HasData(
            new VendaModel
            {
                Id = 1,
                DataVenda = seedDate,
                NomeCliente = "Maria Silva",
                ValorTotal = 275.40M,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            },
            new VendaModel
            {
                Id = 2,
                DataVenda = seedDate.AddDays(1),
                NomeCliente = "João Santos",
                ValorTotal = 95.00M,
                Ativo = true,
                Excluido = false,
                CriadoEm = seedDate,
                AtualizadoEm = seedDate
            }
        );

        modelBuilder.Entity<VendaItemModel>().HasData(
            new VendaItemModel { Id = 1, VendaId = 1, ProdutoSkuId = 1, Quantidade = 1, PrecoUnitario = 180.50M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new VendaItemModel { Id = 2, VendaId = 1, ProdutoSkuId = 3, Quantidade = 1, PrecoUnitario = 79.90M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate },
            new VendaItemModel { Id = 3, VendaId = 2, ProdutoSkuId = 5, Quantidade = 1, PrecoUnitario = 95.00M, Ativo = true, Excluido = false, CriadoEm = seedDate, AtualizadoEm = seedDate }
        );
    }
}

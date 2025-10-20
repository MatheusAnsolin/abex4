namespace SiteBrecho.Models;

public class MovimentacaoModel
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }
    public required ProdutoModel Produto { get; set; }

    public required string Tipo { get; set; } // compra, venda, devolucao
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public DateTime Data { get; set; }//   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
    
    public int AdministradorId { get; set; }
    public AdministradorModel? Administrador { get; set; }

    public int? ClienteId { get; set; }

    public string? Observacao { get; set; }
}

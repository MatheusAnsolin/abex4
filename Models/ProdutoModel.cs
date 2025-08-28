using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBrecho.Models;

public class ProdutoModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal PrecoCusto { get; set; }
    public decimal PrecoVenda { get; set; }

    public int FornecedorId { get; set; }
    public FornecedorModel Fornecedor { get; set; }

    public DateTime CriadoEm { get; set; }//   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
    public DateTime AtualizadoEm { get; set; } //   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso

    public EstoqueModel Estoque { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Models;

public class EstoqueModel
{
    [Key]
    public int ProdutoId { get; set; }
    public int QuantidadeAtual { get; set; }

    public ProdutoModel Produto { get; set; }
}

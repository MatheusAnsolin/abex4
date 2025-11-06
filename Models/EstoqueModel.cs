using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Models;

public class EstoqueModel
{
    [Key]
    public int ProdutoSkuId { get; set; }
    public int QuantidadeAtual { get; set; }

    public ProdutoSkuModel ProdutoSku { get; set; }
}

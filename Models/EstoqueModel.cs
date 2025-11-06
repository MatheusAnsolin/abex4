using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Models;

public class EstoqueModel
{
    [Key]
    public int ProdutoSkuId { get; set; }
    public int QuantidadeAtual { get; set; }

    public bool Ativo { get; set; } = true;
    public bool Excluido { get; set; } = false;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;

    public ProdutoSkuModel ProdutoSku { get; set; }
}

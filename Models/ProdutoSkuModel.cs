using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBrecho.Models;

public class ProdutoSkuModel
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecoVenda { get; set; }

    [Required]
    public int ProdutoId { get; set; }

    [ForeignKey("ProdutoId")]
    public virtual ProdutoModel Produto { get; set; }

    [Required]
    public int ProdutoVariationId1 { get; set; }

    [ForeignKey("ProdutoVariationId1")]
    public virtual ProdutoVariationModel Variacao1 { get; set; }

    public int? ProdutoVariationId2 { get; set; }

    [ForeignKey("ProdutoVariationId2")]
    public virtual ProdutoVariationModel? Variacao2 { get; set; }

    public bool Ativo { get; set; } = true;
    public bool Excluido { get; set; } = false;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
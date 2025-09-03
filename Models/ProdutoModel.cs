using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBrecho.Models;

public class ProdutoModel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    
    [MaxLength(500)]
    public string? Descricao { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecoCusto { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecoVenda { get; set; }
    
    public int? FornecedorId { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow; 
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow; 
}
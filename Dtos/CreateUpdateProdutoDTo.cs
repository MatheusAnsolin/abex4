using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
    public class CreateUpdateProdutoDto
    {
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(500)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O preço de custo é obrigatório.")]
        [Range(0.01, 100000, ErrorMessage = "O preço de custo deve ser maior que zero.")]
        public decimal PrecoCusto { get; set; }

        [Required(ErrorMessage = "O preço de venda é obrigatório.")]
        [Range(0.01, 100000, ErrorMessage = "O preço de venda deve ser maior que zero.")]
        public decimal PrecoVenda { get; set; }

        public int? FornecedorId { get; set; }
    }
}
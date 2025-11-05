using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
    public class CreateUpdateProdutoVariationDto
    {
        [Required(ErrorMessage = "O nome da variação é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string? Descricao { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
    public class CreateVendaDto
    {
        [Required]
        public required string NomeCliente { get; set; }

        [Required]
        [MinLength(1)]
        public required List<VendaItemDto> Itens { get; set; }
    }

    public class VendaItemDto
    {
        [Required]
        public int ProdutoId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}
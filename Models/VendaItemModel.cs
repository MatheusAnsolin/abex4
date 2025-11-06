using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBrecho.Models
{
    public class VendaItemModel
    {
        [Key]
        public int Id { get; set; }

        public int? VendaId { get; set; }
        public VendaModel? Venda { get; set; }

        public int ProdutoId { get; set; }

        [Required]
        public required ProdutoModel Produto { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }
    }
}
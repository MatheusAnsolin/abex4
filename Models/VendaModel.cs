using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBrecho.Models
{
    public class VendaModel
    {
        [Key]
        public int Id { get; set; }

        public required DateTime DataVenda { get; set; }

        public required string NomeCliente { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public required decimal ValorTotal { get; set; }
        public ICollection<VendaItemModel> Itens { get; set; } = new List<VendaItemModel>();
    }
}
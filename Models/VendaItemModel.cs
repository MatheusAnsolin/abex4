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

        public int ProdutoSkuId { get; set; }

        public ProdutoSkuModel? ProdutoSku { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; set; }

        public bool Ativo { get; set; } = true;
        public bool Excluido { get; set; } = false;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
    }
}
namespace SiteBrecho.Dtos
{
    public class VendaDto
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public List<VendaItemResponseDto> Itens { get; set; } = new List<VendaItemResponseDto>();
    }

    public class VendaItemResponseDto
    {
        public int Id { get; set; }
        public int ProdutoSkuId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}


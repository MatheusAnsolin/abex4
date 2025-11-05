namespace SiteBrecho.Dtos
{
    public class ProdutoSKUDto
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int ProdutoVariationId1 { get; set; }
        public int? ProdutoVariationId2 { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
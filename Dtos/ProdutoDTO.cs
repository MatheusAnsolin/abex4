namespace SiteBrecho.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public int? FornecedorId { get; set; }
    }
}
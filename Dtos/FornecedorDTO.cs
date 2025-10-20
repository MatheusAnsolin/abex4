namespace SiteBrecho.Dtos
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CnpjCpf { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required string Endereco { get; set; }
    }
}
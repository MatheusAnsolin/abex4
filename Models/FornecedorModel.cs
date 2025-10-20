namespace SiteBrecho.Models;

public class FornecedorModel
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string CnpjCpf { get; set; }
    public required string Email { get; set; }
    public required string Telefone { get; set; }
    public required string Endereco { get; set; }
    public DateTime CriadoEm { get; set; } //   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
}

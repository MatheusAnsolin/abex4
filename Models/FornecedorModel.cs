namespace SiteBrecho.Models;

public class FornecedorModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CnpjCpf { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }
    public DateTime CriadoEm { get; set; } //   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
    
    public ICollection<ProdutoModel> Produtos { get; set; }
}

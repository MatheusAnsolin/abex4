namespace SiteBrecho.Models;

public class AdministradorModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; }
    public string SenhaHash { get; set; }
    public DateTime CriadoEm { get; set; } //   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
}

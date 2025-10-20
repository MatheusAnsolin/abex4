namespace SiteBrecho.Models;

public class AdministradorModel
{
    public int Id { get; set; }
    public required string Nome { get; set; } = string.Empty;
    public required string Email { get; set; }
    public required string SenhaHash { get; set; }
    public DateTime CriadoEm { get; set; } //   = DateTime.UtcNow; dotnet ef database update dá erro se usar isso
}

using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
    public class CreateUpdateFornecedorDto
    {
        [Required(ErrorMessage = "O nome do fornecedor é obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O cnpj/cpf do fornecedor é obrigatório.")]
        [MaxLength(14)]
        public string CnpjCpf { get; set; }
        
        [Required(ErrorMessage = "O email do fornecedor é obrigatório.")]
        [MaxLength(50)]
        public string Email { get; set; }
        
        [MaxLength(100)]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O endereco do fornecedor é obrigatório.")]
        [MaxLength(100)]
        public string Endereco { get; set; }
    }
}
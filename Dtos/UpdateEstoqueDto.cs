using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
	public class UpdateEstoqueDto
	{
		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser zero ou positiva.")]
		public int QuantidadeAtual { get; set; }
	}
}

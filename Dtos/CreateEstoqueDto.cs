using System.ComponentModel.DataAnnotations;

namespace SiteBrecho.Dtos
{
	public class CreateEstoqueDto
	{
		[Required]
		public int ProdutoSkuId { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser zero ou positiva.")]
		public int QuantidadeAtual { get; set; }
	}
}

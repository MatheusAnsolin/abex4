using AutoMapper;
using SiteBrecho.Dtos;
using SiteBrecho.Models;

namespace SiteBrecho.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoModel, ProdutoDto>();
            CreateMap<ProdutoSkuModel, ProdutoSKUDto>();
            CreateMap<FornecedorModel, FornecedorDto>();
            CreateMap<ProdutoVariationModel, ProdutoVariationDto>();

            CreateMap<CreateUpdateProdutoDto, ProdutoModel>();
            CreateMap<CreateUpdateProductSkuDto, ProdutoSkuModel>();
            CreateMap<CreateUpdateFornecedorDto, FornecedorModel>();
            CreateMap<CreateUpdateProdutoVariationDto, ProdutoVariationModel>();
        }
    }
}
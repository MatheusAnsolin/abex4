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
            CreateMap<FornecedorModel, FornecedorDto>();
            
            CreateMap<CreateUpdateProdutoDto, ProdutoModel>();
            CreateMap<CreateUpdateFornecedorDto, FornecedorModel>();
        }
    }
}
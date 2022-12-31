using AHY.JWPApp.Api.Core.Application.Dto.Product;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;

namespace AHY.JWPApp.Api.Core.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}

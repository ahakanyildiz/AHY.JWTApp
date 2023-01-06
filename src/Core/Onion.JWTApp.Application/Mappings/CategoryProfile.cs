using AutoMapper;
using Onion.JWTApp.Application.Dto;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}

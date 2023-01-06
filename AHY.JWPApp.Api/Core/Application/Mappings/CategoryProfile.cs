using AHY.JWPApp.Api.Core.Application.Dto.Category;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;

namespace AHY.JWPApp.Api.Core.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}

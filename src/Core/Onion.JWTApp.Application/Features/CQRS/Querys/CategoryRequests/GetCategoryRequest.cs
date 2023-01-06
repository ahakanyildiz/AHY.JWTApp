using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Querys.CategoryRequests
{
    public class GetCategoryRequest : IRequest<CategoryListDto>
    {
        public GetCategoryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

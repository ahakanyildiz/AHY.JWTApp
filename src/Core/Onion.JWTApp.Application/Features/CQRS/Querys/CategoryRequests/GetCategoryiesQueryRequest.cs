using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Querys.CategoryRequests
{
    public class GetCategoryiesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}

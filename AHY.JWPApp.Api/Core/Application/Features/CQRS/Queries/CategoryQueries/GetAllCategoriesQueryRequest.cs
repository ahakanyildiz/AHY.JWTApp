using AHY.JWPApp.Api.Core.Application.Dto.Category;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetAllCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
    }
}

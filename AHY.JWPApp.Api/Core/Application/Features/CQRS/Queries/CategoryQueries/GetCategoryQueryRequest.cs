using AHY.JWPApp.Api.Core.Application.Dto.Category;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}

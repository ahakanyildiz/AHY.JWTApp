using AHY.JWPApp.Api.Core.Application.Dto.Product;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.ProductQueries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {

    }
}

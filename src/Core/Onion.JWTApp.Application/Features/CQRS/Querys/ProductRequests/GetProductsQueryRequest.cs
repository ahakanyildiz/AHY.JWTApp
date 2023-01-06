using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Querys.ProductRequests
{
    public class GetProductsQueryRequest : IRequest<IEnumerable<ProductListDto>>
    {
    }
}

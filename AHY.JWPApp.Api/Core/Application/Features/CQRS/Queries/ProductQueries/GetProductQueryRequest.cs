using AHY.JWPApp.Api.Core.Application.Dto.Product;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.ProductQueries
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }

        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}

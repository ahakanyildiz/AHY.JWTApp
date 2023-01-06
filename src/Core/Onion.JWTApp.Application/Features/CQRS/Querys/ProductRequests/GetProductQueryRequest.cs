using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Querys.ProductRequests
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

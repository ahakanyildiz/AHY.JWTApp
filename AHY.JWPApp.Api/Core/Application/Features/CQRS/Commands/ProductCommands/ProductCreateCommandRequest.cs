using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.ProductCommands
{
    public class ProductCreateCommandRequest : IRequest
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

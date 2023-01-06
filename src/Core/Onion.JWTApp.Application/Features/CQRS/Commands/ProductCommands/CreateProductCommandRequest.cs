using MediatR;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands
{
    public class CreateProductCommandRequest : IRequest
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

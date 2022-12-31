using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.ProductCommands
{
    public class ProductRemoveCommandRequest : IRequest
    {
        public ProductRemoveCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

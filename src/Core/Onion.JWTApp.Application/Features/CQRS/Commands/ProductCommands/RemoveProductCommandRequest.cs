using MediatR;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands
{
    public class RemoveProductCommandRequest : IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommandRequest(int id)
        {
            Id = id;
        }
    }
}

using MediatR;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommandRequest : IRequest
    {
        public RemoveCategoryCommandRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

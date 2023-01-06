using MediatR;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.CategoryCommands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}

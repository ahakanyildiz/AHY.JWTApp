using MediatR;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}

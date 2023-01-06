using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands
{
    public class CategoryUpdateCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}

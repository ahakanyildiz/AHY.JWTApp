using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands
{
    public class CategoryCreateCommandRequest : IRequest
    {
        public string? Definition { get; set; }
    }
}

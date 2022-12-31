using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands
{
    public class CategoryRemoveCommandRequest : IRequest
    {
        public int Id { get; set; }

        public CategoryRemoveCommandRequest(int id)
        {
            Id = id;
        }
    }
}

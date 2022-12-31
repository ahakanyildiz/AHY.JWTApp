using MediatR;

namespace AHY.JWTApp.Api.Core.Application.Features.CQRS.Commands.UserCommands
{
    public class RegisterUserCommandRequest : IRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Commands.UserCommands
{
    public class RegisterUserCommandRequest : IRequest<CreatedUserDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

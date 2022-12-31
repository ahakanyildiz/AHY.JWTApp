using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AHY.JWTApp.Api.Core.Application.Enums;
using AHY.JWTApp.Api.Core.Application.Features.CQRS.Commands.UserCommands;
using MediatR;

namespace AHY.JWTApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.UserCommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _userRepository;

        public RegisterUserCommandHandler(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userRepository.CreateAsync(new AppUser
            {
                UserName = request.Username,
                Password = request.Password,
                AppRoleId=(int)RoleType.Member
            });

            return Unit.Value;
        }
    }
}

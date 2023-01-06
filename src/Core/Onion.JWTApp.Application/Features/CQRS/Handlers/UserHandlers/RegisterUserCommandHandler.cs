using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Enums;
using Onion.JWTApp.Application.Features.CQRS.Commands.UserCommands;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;


namespace Onion.JWTApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<CreatedUserDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByFilterAsync(x => x.UserName == request.Username);
            if (user == null)
            {
                await _repository.CreateAsync(new AppUser { UserName = request.Username, Password = request.Password,AppRoleId=(int)RoleType.Member});

                user = await _repository.GetByFilterAsync(x => x.UserName == request.Username);
                return new CreatedUserDto() { Id = user.Id };
            }

            return new CreatedUserDto { Id = 0 };


        }
    }
}

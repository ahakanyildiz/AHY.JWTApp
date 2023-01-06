using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Features.CQRS.Querys.UserRequests;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.UserHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private IRepository<AppUser> _userRepository;
        private IRepository<AppRole> _roleRepository;

        public CheckUserQueryHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await _userRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.IsExist = true;
                dto.Username = user.UserName;
                dto.Role = (await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId))?.Definition;
                dto.Id = user.Id;
            }

            return dto;
        }
    }
}

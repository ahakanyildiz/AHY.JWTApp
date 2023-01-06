using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AHY.JWTApp.Api.Core.Application.Dto.User;
using AHY.JWTApp.Api.Core.Application.Features.CQRS.Queries.UserQueries;
using MediatR;

namespace AHY.JWTApp.Api.Core.Application.Features.CQRS.Handlers.QueryHandlers.UserQueryHandlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

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
                dto.Id = user.Id;
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;
            }
            return dto;
        }
    }
}

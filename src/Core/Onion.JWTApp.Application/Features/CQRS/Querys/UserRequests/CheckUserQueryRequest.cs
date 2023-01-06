using MediatR;
using Onion.JWTApp.Application.Dto;

namespace Onion.JWTApp.Application.Features.CQRS.Querys.UserRequests
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

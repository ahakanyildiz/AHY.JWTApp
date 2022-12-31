using AHY.JWTApp.Api.Core.Application.Dto.User;
using MediatR;

namespace AHY.JWTApp.Api.Core.Application.Features.CQRS.Queries.UserQueries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string? Username { get; set; } = null!;//Default değeri null olamaz.(Alternatif =>String.Empty)
        public string? Password { get; set; } = null!;
    }
}

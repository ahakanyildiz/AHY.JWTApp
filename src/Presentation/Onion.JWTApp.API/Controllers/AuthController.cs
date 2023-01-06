using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.JWTApp.API.Tools;
using Onion.JWTApp.Application.Features.CQRS.Commands.UserCommands;
using Onion.JWTApp.Application.Features.CQRS.Querys.UserRequests;

namespace Onion.JWTApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            var user = await _mediator.Send(request);
            return user.Id != 0 ? Created("", user) : BadRequest("Böyle bir kullanıcı adı zaten var ");
        }

    }
}

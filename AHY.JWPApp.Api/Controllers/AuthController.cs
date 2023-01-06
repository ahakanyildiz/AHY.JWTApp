using AHY.JWTApp.Api.Core.Application.Features.CQRS.Commands.UserCommands;
using AHY.JWTApp.Api.Core.Application.Features.CQRS.Queries.UserQueries;
using AHY.JWTApp.Api.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AHY.JWTApp.Api.Controllers
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
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(response));
            else
                return BadRequest("Kullancı adı ve ya şifre hatalı");

        }
    }
}

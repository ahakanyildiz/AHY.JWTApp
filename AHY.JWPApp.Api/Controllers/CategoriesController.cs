using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands;
using AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AHY.JWPApp.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _mediator.Send(new GetCategoryQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new CategoryRemoveCommandRequest(id));
            return NoContent();
        }
    }
}

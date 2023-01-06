using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JWTApp.Application.Features.CQRS.Commands.CategoryCommands;
using Onion.JWTApp.Application.Features.CQRS.Querys.CategoryRequests;

namespace Onion.JWTApp.API.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _mediator.Send(new GetCategoryiesQueryRequest());
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _mediator.Send(new GetCategoryRequest(id));
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommandRequest(id));
            return NoContent();
        }

    }
}

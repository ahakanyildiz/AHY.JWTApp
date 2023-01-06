using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands;
using Onion.JWTApp.Application.Features.CQRS.Querys.ProductRequests;

namespace Onion.JWTApp.API.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _mediator.Send(new GetProductsQueryRequest());
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _mediator.Send(new GetProductQueryRequest(id));
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommandRequest(id));
            return NoContent();
        }

    }
}

using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.ProductCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.ProductCommandHandlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest>
    {
        private readonly IRepository<Product> _productRepository;

        public ProductUpdateCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var unChanged = await _productRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (unChanged != null)
            {
                await _productRepository.UpdateAsync(unChanged, new Product
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    Price = request.Price,
                    Stock = request.Stock
                });
            }

            return Unit.Value;

        }
    }
}

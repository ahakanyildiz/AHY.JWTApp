using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.ProductCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.ProductCommandHandlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommandRequest>
    {
        private readonly IRepository<Product> _productRepository;

        public ProductCreateCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.CreateAsync(new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId,
            });
            return Unit.Value;
        }
    }
}

using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.ProductCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.ProductCommandHandlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommandRequest>
    {
        private readonly IRepository<Product> _productRepository;
        public ProductRemoveCommandHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(ProductRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity =await _productRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (deletedEntity != null)
            {
                await _productRepository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}

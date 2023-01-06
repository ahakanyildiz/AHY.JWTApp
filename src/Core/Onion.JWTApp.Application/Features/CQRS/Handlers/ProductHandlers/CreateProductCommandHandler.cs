using MediatR;
using Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Product { Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId });
            return Unit.Value;
        }
    }
}

using MediatR;
using Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(new Product { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.Stock, CategoryId = request.CategoryId });
            return Unit.Value;
        }
    }
}

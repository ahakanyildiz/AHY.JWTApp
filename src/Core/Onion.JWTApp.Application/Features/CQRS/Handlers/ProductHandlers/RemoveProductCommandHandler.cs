using MediatR;
using Onion.JWTApp.Application.Features.CQRS.Commands.ProductCommands;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            await _repository.Remove(entity);
            return Unit.Value;
        }
    }
}

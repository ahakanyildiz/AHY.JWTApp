using MediatR;
using Onion.JWTApp.Application.Features.CQRS.Commands.CategoryCommands;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            await _repository.Remove(category);
            return Unit.Value;
        }
    }
}

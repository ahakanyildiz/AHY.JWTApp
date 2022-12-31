using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.CategoryCommandHandlers
{
    public class CategoryRemoveCommandHandler : IRequestHandler<CategoryRemoveCommandRequest>
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryRemoveCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CategoryRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity =await _categoryRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (deletedEntity != null)
            {
               await _categoryRepository.RemoveAsync(deletedEntity);
            }
            return Unit.Value;
        }
    }
}

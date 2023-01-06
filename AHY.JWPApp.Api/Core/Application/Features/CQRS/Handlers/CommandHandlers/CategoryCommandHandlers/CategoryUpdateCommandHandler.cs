using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.CategoryCommandHandlers
{
    public class CategoryUpdateCommandHandler : IRequestHandler<CategoryUpdateCommandRequest>
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryUpdateCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var unChangedEntity = await _categoryRepository.GetByFilterAsync(x => x.Id == request.Id);
            if (unChangedEntity != null)
            {
                await _categoryRepository.UpdateAsync(unChangedEntity, new Category
                {
                    Id = request.Id,
                    Definition = request.Definition,
                });
            }
            return Unit.Value;

        }
    }
}

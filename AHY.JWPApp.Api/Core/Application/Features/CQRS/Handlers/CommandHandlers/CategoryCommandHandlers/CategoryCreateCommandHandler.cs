using AHY.JWPApp.Api.Core.Application.Features.CQRS.Commands.CategoryCommands;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.CommandHandlers.CategoryCommandHandlers
{
    public class CategoryCreateCommandHandler : IRequestHandler<CategoryCreateCommandRequest>
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryCreateCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryRepository.CreateAsync(new Category
            {
                Definition = request.Definition
            });
            return Unit.Value;
        }
    }
}

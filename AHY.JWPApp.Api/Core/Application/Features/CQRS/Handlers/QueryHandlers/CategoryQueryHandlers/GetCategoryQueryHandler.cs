using AHY.JWPApp.Api.Core.Application.Dto.Category;
using AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.CategoryQueries;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.QueryHandlers.CategoryQueryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data =await _categoryRepository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}

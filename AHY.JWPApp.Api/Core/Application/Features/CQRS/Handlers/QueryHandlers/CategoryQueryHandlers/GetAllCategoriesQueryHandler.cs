using AHY.JWPApp.Api.Core.Application.Dto.Category;
using AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.CategoryQueries;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.QueryHandlers.CategoryQueryHandlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(data);
        }
    }
}

using AutoMapper;
using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Features.CQRS.Querys.CategoryRequests;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoryiesQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetCategoriesQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoryiesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryListDto>>(categories);
        }
    }
}

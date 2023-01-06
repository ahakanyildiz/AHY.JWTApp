using AutoMapper;
using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Features.CQRS.Querys.CategoryRequests;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryRequest, CategoryListDto>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryListDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<CategoryListDto>(category);
        }
    }
}

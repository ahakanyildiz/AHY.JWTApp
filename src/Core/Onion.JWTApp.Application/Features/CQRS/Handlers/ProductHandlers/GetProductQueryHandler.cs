using AutoMapper;
using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Features.CQRS.Querys.ProductRequests;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductListDto>(await _repository.GetByIdAsync(request.Id));
            return product;
        }
    }
}

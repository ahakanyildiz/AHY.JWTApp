using AutoMapper;
using MediatR;
using Onion.JWTApp.Application.Dto;
using Onion.JWTApp.Application.Features.CQRS.Querys.ProductRequests;
using Onion.JWTApp.Application.Interfaces;
using src.Core.Onion.JwtApp.Domain.Entities;


namespace Onion.JWTApp.Application.Features.CQRS.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, IEnumerable<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductListDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productListDto = _mapper.Map<IEnumerable<ProductListDto>>(await _repository.GetAllAsync());

            return productListDto;
        }


    }
}

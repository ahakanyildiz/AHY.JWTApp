using AHY.JWPApp.Api.Core.Application.Dto.Product;
using AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.ProductQueries;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}

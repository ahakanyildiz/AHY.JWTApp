using AHY.JWPApp.Api.Core.Application.Dto.Product;
using AHY.JWPApp.Api.Core.Application.Features.CQRS.Queries.ProductQueries;
using AHY.JWPApp.Api.Core.Application.Interfaces;
using AHY.JWPApp.Api.Core.Domain;
using AutoMapper;
using MediatR;

namespace AHY.JWPApp.Api.Core.Application.Features.CQRS.Handlers.QueryHandlers.ProductQueryHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<ProductListDto>(data);
        }
    }
}

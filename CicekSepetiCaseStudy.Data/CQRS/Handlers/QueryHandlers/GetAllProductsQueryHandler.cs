using CicekSepetiCaseStudy.Core.Models;
using CicekSepetiCaseStudy.Data.CQRS.Queries.Request;
using CicekSepetiCaseStudy.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CicekSepetiCaseStudy.Data.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<BasketProduct>>
    {
        private readonly ICartService cartService;
        public GetAllProductsQueryHandler(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public async Task<IEnumerable<BasketProduct>> Handle(GetAllProductsQuery query, CancellationToken ct)
        {
            return await cartService.GetAllProducts();
        }
    }
}

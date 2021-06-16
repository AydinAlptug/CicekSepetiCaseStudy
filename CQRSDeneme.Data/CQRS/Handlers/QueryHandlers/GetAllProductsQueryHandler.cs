using CQRSDeneme.Core.Models;
using CQRSDeneme.Data.CQRS.Queries.Request;
using CQRSDeneme.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDeneme.Data.CQRS.Handlers.QueryHandlers
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

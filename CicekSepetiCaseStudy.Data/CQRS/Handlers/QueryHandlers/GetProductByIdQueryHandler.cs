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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, BasketProduct>
    {
        private readonly ICartService cartService;
        public GetProductByIdQueryHandler(ICartService cartService)
        {
            this.cartService = cartService;
        }
        public async Task<BasketProduct> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await cartService.GetProductById(query.id);
        }

    }
}

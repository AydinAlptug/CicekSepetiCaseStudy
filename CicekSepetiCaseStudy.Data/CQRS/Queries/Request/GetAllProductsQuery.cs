using CQRSDeneme.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.CQRS.Queries.Request
{
    public class GetAllProductsQuery : IRequest<IEnumerable<BasketProduct>>
    {

    }
}

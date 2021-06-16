using CQRSDeneme.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.CQRS.Queries.Request
{
    public class GetProductByIdQuery : IRequest<BasketProduct>
    {
        public int id { get; set; }
    }
}

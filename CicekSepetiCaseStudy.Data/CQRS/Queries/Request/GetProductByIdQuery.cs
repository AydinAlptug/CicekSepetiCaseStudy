using CicekSepetiCaseStudy.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepetiCaseStudy.Data.CQRS.Queries.Request
{
    public class GetProductByIdQuery : IRequest<BasketProduct>
    {
        public int id { get; set; }
    }
}

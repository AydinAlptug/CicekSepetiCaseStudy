using CicekSepetiCaseStudy.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepetiCaseStudy.Data.CQRS.Queries.Request
{
    public class GetAllProductsQuery : IRequest<IEnumerable<BasketProduct>>
    {

    }
}

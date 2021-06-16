using CQRSDeneme.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.CQRS.Commands.Request
{
    public class AddToCartCommand : IRequest<BasketProduct>
    {
        public int productId { get; set; }
        public int amount { get; set; }
        public DateTime creationDate { get; set; }

    }
}

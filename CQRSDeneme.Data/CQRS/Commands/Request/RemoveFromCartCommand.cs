using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSDeneme.Data.CQRS.Commands.Request
{
    public class RemoveFromCartCommand : IRequest<int>
    {
        public int productId { get; set; }
        public int amount { get; set; }
    }
}

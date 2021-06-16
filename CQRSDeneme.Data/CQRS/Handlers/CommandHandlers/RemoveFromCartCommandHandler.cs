using CQRSDeneme.Data.CQRS.Commands.Request;
using CQRSDeneme.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDeneme.Data.CQRS.Handlers.CommandHandlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, int>
    {
        private readonly ICartService cartService;
        public RemoveFromCartCommandHandler(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<int> Handle(RemoveFromCartCommand command, CancellationToken cancellationToken)
        {
            var product = await cartService.GetProductById(command.productId);
            if (product == null) 
                return default;

            if(command.amount < product.amount) // decrease amount in cart by command.amount times
            {
                product.amount -= command.amount;
                return await cartService.UpdateProductInCart(product);
            }

            return await cartService.RemoveProductFromCart(product); // remove all amount in cart
        }
    }
}

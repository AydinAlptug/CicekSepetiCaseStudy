using CQRSDeneme.Core.Models;
using CQRSDeneme.Data.CQRS.Commands.Request;
using CQRSDeneme.Data.Services.StrockService;
using CQRSDeneme.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDeneme.Data.CQRS.Handlers.CommandHandlers
{
    public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, BasketProduct>
    {
        private readonly ICartService cartService;
        private readonly IStockService stockService;
        public AddToCartCommandHandler(ICartService cartService, IStockService stockService)
        {
            this.cartService = cartService;
            this.stockService = stockService;
        }

        public async Task<BasketProduct> Handle(AddToCartCommand command, CancellationToken cancellationToken)
        {

            //checking stock status in controller is more resource friendly

            Product stockProduct = await stockService.GetStockProduct(command.productId);
            var basketProduct = cartService.GetProductById(command.productId).Result;
            if (basketProduct == null) // very first time adding the product to cart
            {
                basketProduct = new BasketProduct
                {
                    basketProductGuid = Guid.NewGuid(),
                    productId = command.productId,
                    productName = stockProduct.productName,
                    description = stockProduct.description,
                    amount = command.amount,
                    creationDate = command.creationDate
                };

                await cartService.AddProductToCartAsync(basketProduct);
            }
            else  // increment the amount of existing product in cart
            {
                basketProduct.amount += command.amount;
                basketProduct.creationDate = command.creationDate;

                if (basketProduct.amount > stockProduct.amount) // if new amount exceeds stock
                    return default;//null;

                await cartService.UpdateProductInCart(basketProduct);
            }

            return basketProduct;
        }
    }
}

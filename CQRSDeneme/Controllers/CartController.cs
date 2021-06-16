using CQRSDeneme.Core.Models;
using CQRSDeneme.Data.CQRS.Commands.Request;
using CQRSDeneme.Data.CQRS.Queries.Request;
using CQRSDeneme.Data.Services.StrockService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSDeneme.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IStockService stockService;

        public CartController(IMediator mediator, IStockService stockService)
        {
            this.mediator = mediator;
            this.stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllProductsQuery queryModel = new GetAllProductsQuery();

            IEnumerable<BasketProduct> allProducts = await mediator.Send(queryModel);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetProductByIdQuery queryModel = new GetProductByIdQuery
            {
                id = id
            };

            BasketProduct product = await mediator.Send(queryModel);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddToCartCommand commandModel)
        {
            int stockAmount = await stockService.CheckStockAmount(commandModel.productId);

            if(stockAmount == 0)
                return BadRequest("No stock");
            if (stockAmount < commandModel.amount)
                return BadRequest("Product amount cannot exceed " + stockAmount); //
            if (commandModel.amount <= 0)
                return BadRequest("An error occured."); //

            BasketProduct product = await mediator.Send(commandModel);

            if(product == null)
                return BadRequest("Product amount in your cart cannot exceed " + stockAmount); //

            return Ok(product);
        }
        /*
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, UpdateProductCommand commandModel)
        {
            if(id != commandModel.productId)
            {
                return BadRequest();
            }
            int result = await mediator.Send(commandModel);

            return Ok(result);
        }
        */
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveFromCartCommand commandModel)
        {

            int result = await mediator.Send(commandModel);
            return Ok(result);
        }

    }
}

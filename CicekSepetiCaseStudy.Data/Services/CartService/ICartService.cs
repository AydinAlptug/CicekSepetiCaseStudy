using CQRSDeneme.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDeneme.Services
{
    public interface ICartService
    {
        Task<IEnumerable<BasketProduct>> GetAllProducts();
        Task<BasketProduct> GetProductById(int id);
        Task<BasketProduct> AddProductToCartAsync(BasketProduct product);
        Task<int> UpdateProductInCart(BasketProduct product);
        Task<int> RemoveProductFromCart(BasketProduct product);
    }
}

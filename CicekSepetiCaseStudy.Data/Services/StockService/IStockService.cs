using CicekSepetiCaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepetiCaseStudy.Data.Services.StrockService
{
    public interface IStockService
    {
        Task<int> CheckStockAmount(int productId);
        Task<StockProduct> GetStockProduct(int productId);
    }
}

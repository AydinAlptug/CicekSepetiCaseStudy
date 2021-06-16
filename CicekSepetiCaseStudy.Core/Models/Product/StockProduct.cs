using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepetiCaseStudy.Core.Models
{
    public class StockProduct : Product
    {
        [Key]
        public string stockPlace { get; set; } // farklı yerlerde kullanılmak üzere Adres sınıfı tanımlanabilir
    }
}

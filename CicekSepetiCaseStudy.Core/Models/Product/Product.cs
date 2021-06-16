using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepetiCaseStudy.Core.Models
{
    public abstract class Product
    {
        //[Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int amount { get; set; }
    }
}

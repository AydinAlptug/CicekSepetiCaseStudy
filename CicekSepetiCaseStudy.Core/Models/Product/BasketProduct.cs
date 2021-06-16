using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CicekSepetiCaseStudy.Core.Models
{
    public class BasketProduct : Product
    {
        [Key]
        public Guid basketProductGuid { get; set; }
        public DateTime creationDate { get; set; }
    }
}

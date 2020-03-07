using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Display(Name = "Product Name")]
        public string ProdName { get; set; }
        [Display(Name = "Quantity Available")]
        public int QtyAvail { get; set; }
        [Display(Name = "Product Category")]
        public string ProdCat { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebApplication_FitToFast.Models
{
    public class Inventory
    {
        [Key]
        public int pId { get; set; }

        [Required(ErrorMessage = "Product type is required")]
        public int typeId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string pName { get; set; }
        public string pDetail { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        public decimal pPrice { get; set; }

        //[Required(ErrorMessage = "Product image is required")]
        public string pImage { get; set; }
        public string pTexture { get; set; }
        public int XS { get; set; }
        public int S { get; set; }
        public int M { get; set; }
        public int L { get; set; }
        public int XL { get; set; }
        public DateTime Date { get; set; }
    }
    public class PurchaseHistory
    {
        [Key]
        public int pId { get; set; }

        public int typeId { get; set; }
        public string pName { get; set; }
        public string pDetail { get; set; }
        public decimal pPrice { get; set; }
        public string pImage { get; set; }
        public string pTexture { get; set; }
        public int XS { get; set; }
        public int S { get; set; }
        public int M { get; set; }
        public int L { get; set; }
        public int XL { get; set; }
        public DateTime Date { get; set; }
    }
}
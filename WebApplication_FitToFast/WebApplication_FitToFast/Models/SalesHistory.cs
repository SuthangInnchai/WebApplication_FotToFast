using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_FitToFast.Models
{
    public class SalesHistory
    {
        [Key]
        public int TblId { get; set; }
        public int Id { get; set; }
        public int ClothTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetail { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public DateTime SouldOuteDate { get; set; }
    }
}
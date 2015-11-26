using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_FitToFast.Helpers
{
    public class SizeHelper
    {
        public static IEnumerable<SelectListItem> GetSize()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
            new SelectListItem() {Text = "Selected a size of product", Value = "0"},
            new SelectListItem() {Text = "XS", Value = "XS"},
             new SelectListItem() {Text = "S", Value = "S"},
              new SelectListItem() {Text = "M", Value = "M"},
               new SelectListItem() {Text = "L", Value = "L"},
                new SelectListItem() {Text = "XL", Value = "XL"},
            };
            return items;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_FitToFast.Helpers
{
    public class SelectListItemHelper
    {
        public static IEnumerable<SelectListItem> GetTypeIdList()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
            new SelectListItem() {Text = "Selected a type of product type", Value = ""},
            new SelectListItem() {Text = "Short T-shirt", Value = "1"},
            new SelectListItem() {Text = "Long T-shirt", Value = "2"},
            new SelectListItem() {Text = "Polo shirt", Value = "3"},
            };
            return items;
        }
    }
}
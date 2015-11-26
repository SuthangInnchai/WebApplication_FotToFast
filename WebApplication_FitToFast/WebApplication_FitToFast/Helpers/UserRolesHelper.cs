using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_FitToFast.Helpers
{
    public class UserRolesHelper
    {
        public static IEnumerable<SelectListItem> GetTypeIdList()
        {
            IList<SelectListItem> userRole = new List<SelectListItem>
            {
            new SelectListItem() {Text = "Selected a user roles"},
            new SelectListItem() {Text = "Admin", Value = "Admin"},
            new SelectListItem() {Text = "Employee", Value = "Employee"},
           
            };
            return userRole;
        }
    }
}
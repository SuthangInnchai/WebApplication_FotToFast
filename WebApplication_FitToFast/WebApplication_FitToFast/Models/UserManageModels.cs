using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_FitToFast.Models
{
    public class UserManageModels
    {
            public ApplicationUser User { get; set; }
            public IdentityRole Roles { get; set; }
    }
}
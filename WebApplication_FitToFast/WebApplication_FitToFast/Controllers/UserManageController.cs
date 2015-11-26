using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_FitToFast.Models;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication_FitToFast.Controllers
{
    public class UserManageController : Controller
    {
         public UserManageController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }
                public UserManageController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
      

        RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(
       new RoleStore<IdentityRole>(new ApplicationDbContext()));

        
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: UserManage
        public ActionResult Index()
        {
            List<UserManageModels> user = new List<UserManageModels>();

            foreach (var item in db.Users.ToList())
            {
                UserManageModels manage = new UserManageModels();
                manage.User = item;
                var rolename = UserManager.GetRoles(item.Id).FirstOrDefault();
                if (rolename != null)
                {
                    manage.Roles = RoleManager.FindByName(rolename);
                }
                user.Add(manage);
            }
            return View(user);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManageModels manage = new UserManageModels();
            manage.User = await UserManager.FindByIdAsync(id);
            var rolename = UserManager.GetRoles(id).FirstOrDefault();
            if (rolename != null)
            {
                var roleofuser = RoleManager.FindByName(rolename);
                manage.Roles = roleofuser;
            }

            if (manage == null)
            {
                return HttpNotFound();
            }
            return View(manage);
        }

        // POST: /Mock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: /Mock/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManageModels manage = new UserManageModels();
            manage.User = await UserManager.FindByIdAsync(id);
            var rolename = UserManager.GetRoles(id).FirstOrDefault();
            if (rolename != null)
            {
                var roleofuser = RoleManager.FindByName(rolename);
                manage.Roles = roleofuser;
            }
            if (manage == null)
            {
                return HttpNotFound();
            }
            return View(manage);
        }

        // POST: /Mock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserManageModels manage)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appuser = UserManager.FindById(manage.User.Id);
                appuser.UserName = manage.User.UserName;
                //appuser.Roles = manage.User.Roles;
                await UserManager.UpdateAsync(appuser);

                await UserManager.RemoveFromRoleAsync(manage.User.Id, "Employee");
                await UserManager.RemoveFromRoleAsync(manage.User.Id, "Admin");
                await UserManager.AddToRoleAsync(manage.User.Id, manage.Roles.Name);
                return RedirectToAction("Index");
            }
            return View(manage);
        }
    }
}
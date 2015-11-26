using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication_FitToFast.Models;

namespace WebApplication_FitToFast.Controllers
{
    public class StatisticViewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult StatisticIndex()
        {
            return View();
        }
        public JsonResult GetProductAddingData()
        {
            var getCompanyData = db.ProductStores.ToList();
            return Json(getCompanyData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductExsitingData()
        {
            var getProductData = db.Products.ToList();
            return Json(getProductData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDaySoldOutData()
        {
            var getProductData = db.Inventories.ToList();
            return Json(getProductData, JsonRequestBehavior.AllowGet);
        }
/*
        public ActionResult AlertNotic(Inventory notic, int id)
        {
             var countXS = db.Products.Where(s => s.pId.Equals(notic.pId)).Take(1).Single().XS;
             var countS = db.Products.Where(s => s.pId.Equals(notic.pId)).Take(1).Single().S;
             var countM = db.Products.Where(s => s.pId.Equals(notic.pId)).Take(1).Single().M;
             var countL = db.Products.Where(s => s.pId.Equals(notic.pId)).Take(1).Single().L;
             var countXL = db.Products.Where(s => s.pId.Equals(notic.pId)).Take(1).Single().XL;

             while(notic.XS<3||notic.S<3||notic.M<3||notic.L<3||notic.XL<3)
             {
              
             }

             return noticProduct;
        }*/
    }
}

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
    public class InventoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventories
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        /*
        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesHistory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
        */
        // GET: Inventories/Create
        public ActionResult Create( int id)
        {
            Inventory item = db.Products.Find(id);
            ViewBag.ItemID = item.pId;
            ViewBag.ItemTypeId = item.typeId;
            ViewBag.ItemName = item.pName;
            ViewBag.ItemDetail = item.pDetail;
            ViewBag.ItemPrice = item.pPrice;
            ViewBag.ItemXS = item.XS;
            ViewBag.ItemS = item.S;
            ViewBag.ItemM = item.M;
            ViewBag.ItemL = item.L;
            ViewBag.ItemXL = item.XL;
            ViewBag.ItemDate = item.Date;

            ViewBag.ItemImg = item.pImage;
            ViewBag.ItemImgTexture = item.pTexture;

            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TblId,Id,ClothTypeId,ProductName,ProductDetail,Price,Size,Quantity,SouldOuteDate")] SalesHistory inventory)
        {
            if (ModelState.IsValid)
            {
                //adding process here!!!

                SalesHistory inv = new SalesHistory();
                inv.TblId = inventory.TblId;
                inv.Id = inventory.Id;
                inv.ClothTypeId = inventory.ClothTypeId;
                inv.ProductName = inventory.ProductName;
                inv.ProductDetail = inventory.ProductDetail;
                inv.Price = inventory.Price;
                inv.Size = inventory.Size;
                inv.Quantity = inventory.Quantity;
                inv.SouldOuteDate = DateTime.Now;
                
                db.Inventories.Add(inv);
                db.SaveChanges();

                // updat table of product/////

                if (inv.Size.Equals("XS"))
                {
                    int NowOnStock = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single().XS;
                   
                    int Quantity = inventory.Quantity;
                    int result = NowOnStock - Quantity;
                    var content = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single();
                    content.XS = result;
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }

                if (inventory.Size.Equals("S"))
                {
                    int NowOnStock = db.Products.Where(m => m.pId.Equals(inventory.Id)).Take(1).Single().S;
                    int Quantity = inventory.Quantity;
                    int result = NowOnStock - Quantity;
                    var content = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single();
                    content.S = result;
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (inventory.Size.Equals("M"))
                {
                    int NowOnStock = db.Products.Where(m => m.pId.Equals(inventory.Id)).Take(1).Single().M;
                    int Quantity = inventory.Quantity;
                    int result = NowOnStock - Quantity;
                    var content = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single();
                    content.M = result;
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (inventory.Size.Equals("L"))
                {
                    int NowOnStock = db.Products.Where(m => m.pId.Equals(inventory.Id)).Take(1).Single().L;
                    int Quantity = inventory.Quantity;
                    int result = NowOnStock - Quantity;
                    var content = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single();
                    content.L = result;
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (inventory.Size.Equals("XL"))
                {
                    int NowOnStock = db.Products.Where(m => m.pId.Equals(inventory.Id)).Take(1).Single().XL;
                    int Quantity = inventory.Quantity;
                    int result = NowOnStock - Quantity;
                    var content = db.Products.Where(s => s.pId.Equals(inventory.Id)).Take(1).Single();
                    content.XL = result;
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if (inv.ClothTypeId.Equals("0"))
                {
                    ModelState.AddModelError("","Product type is require");
                }
               
                return RedirectToAction("Index");
            }
     
            
            return View(inventory);
        }
        /*
        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesHistory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TblId,Id,ClothTypeId,ProductName,ProductDetail,Price,Size,Quantity,SouldOuteDate")] SalesHistory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesHistory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesHistory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

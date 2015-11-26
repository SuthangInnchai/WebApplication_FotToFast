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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pId,typeId,pName,pDetail,pPrice,pImage,pTexture,XS,S,M,L,XL,Date")] Inventory products, HttpPostedFileBase productImg, HttpPostedFileBase textureImg)
        {
            if (ModelState.IsValid)
            {
                string productImage = System.IO.Path.GetFileName(productImg.FileName);
                string productImgPath = Server.MapPath("~/ProductImages/" + productImage);
                productImg.SaveAs(productImgPath);

                string textureImage = System.IO.Path.GetFileName(textureImg.FileName);
                string textureImgPath = Server.MapPath("~/TextureImages/" + textureImage);
                textureImg.SaveAs(textureImgPath);

                Inventory addFotUpdate = new Inventory();   
                addFotUpdate.pId = products.pId;
                addFotUpdate.typeId = products.typeId;
                addFotUpdate.pName = products.pName;
                addFotUpdate.pDetail = products.pDetail;
                addFotUpdate.pPrice = products.pPrice;
                addFotUpdate.pImage = productImage;
                addFotUpdate.pTexture = textureImage;
                addFotUpdate.XS = products.XS;
                addFotUpdate.S = products.S;
                addFotUpdate.M = products.M;
                addFotUpdate.L = products.L;
                addFotUpdate.XL = products.XL;
                addFotUpdate.Date = DateTime.Now;

                db.Products.Add(addFotUpdate);
                db.SaveChanges();

                PurchaseHistory addForShow = new PurchaseHistory();
                addForShow.typeId = products.typeId;
                addForShow.pName = products.pName;
                addForShow.pDetail = products.pDetail;
                addForShow.pPrice = products.pPrice;
                addForShow.pImage = productImage;
                addForShow.pTexture = textureImage;
                addForShow.XS = products.XS;
                addForShow.S = products.S;
                addForShow.M = products.M;
                addForShow.L = products.L;
                addForShow.XL = products.XL;
                addForShow.Date = DateTime.Now;

                db.ProductStores.Add(addForShow);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pId,typeId,pName,pDetail,pPrice,pImage,pTexture,XS,S,M,L,XL,Date")] Inventory products)
        {
            if (ModelState.IsValid)
            {
                Inventory editForUpdate = new Inventory();
                editForUpdate.pId = products.pId;
                editForUpdate.typeId = products.typeId;
                editForUpdate.pName = products.pName;
                editForUpdate.pDetail = products.pDetail;
                editForUpdate.pPrice = products.pPrice;
                editForUpdate.pImage = products.pImage;
                editForUpdate.pTexture = products.pTexture;
                editForUpdate.XS = products.XS;
                editForUpdate.S = products.S;
                editForUpdate.M = products.M;
                editForUpdate.L = products.L;
                editForUpdate.XL = products.XL;
                editForUpdate.Date = products.Date;

                db.Entry(editForUpdate).State = EntityState.Modified;
                db.SaveChanges();

                PurchaseHistory editForShow = new PurchaseHistory();
                editForShow.pId = products.pId;
                editForShow.typeId = products.typeId;
                editForShow.pName = products.pName;
                editForShow.pDetail = products.pDetail;
                editForShow.pPrice = products.pPrice;
                editForShow.pImage = products.pImage;
                editForShow.pTexture = products.pTexture;
                editForShow.XS = products.XS;
                editForShow.S = products.S;
                editForShow.M = products.M;
                editForShow.L = products.L;
                editForShow.XL = products.XL;
                editForShow.Date = products.Date;

                db.Entry(editForShow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string productImg1, string textureImg1)
        {
            productImg1 = Server.MapPath("~/ProductImages/" + db.Products.Find(id).pImage);
            textureImg1 = Server.MapPath("~/TextureImages/" + db.Products.Find(id).pTexture);
            if (System.IO.File.Exists(productImg1) && System.IO.File.Exists(textureImg1))
            {
                System.IO.File.Delete(productImg1);
                System.IO.File.Delete(textureImg1);
            }

            Inventory products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            PurchaseHistory productStore = db.ProductStores.Find(id);
            db.ProductStores.Remove(productStore);
            db.SaveChanges();
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
    }
}

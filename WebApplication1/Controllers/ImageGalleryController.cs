using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ImageGalleryController : Controller
    {
        private ImageDbConnectionContext db = new ImageDbConnectionContext();

        // GET: ImageGallery
        public ActionResult Index()
        {
            var imagesModel = new ImageGalleryModel();
            var imageFiles = Directory.GetFiles(Server.MapPath("~/Images/"));
            foreach (var item in imageFiles)
            {
                imagesModel.ImageList.Add(Path.GetFileName(item));
            }
            return View(imagesModel);

        }

        // GET: ImageGallery/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGalleryModel imageGalleryModel = db.ImageGallery.Find(id);
            if (imageGalleryModel == null)
            {
                return HttpNotFound();
            }
            return View(imageGalleryModel);
        }

        // GET: ImageGallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageGallery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ImagePath")] ImageGalleryModel imageGalleryModel)
        {
            if (ModelState.IsValid)
            {
                imageGalleryModel.ID = Guid.NewGuid();
                db.ImageGallery.Add(imageGalleryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imageGalleryModel);
        }

        // GET: ImageGallery/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGalleryModel imageGalleryModel = db.ImageGallery.Find(id);
            if (imageGalleryModel == null)
            {
                return HttpNotFound();
            }
            return View(imageGalleryModel);
        }

        // POST: ImageGallery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ImagePath")] ImageGalleryModel imageGalleryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageGalleryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageGalleryModel);
        }

        // GET: ImageGallery/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageGalleryModel imageGalleryModel = db.ImageGallery.Find(id);
            if (imageGalleryModel == null)
            {
                return HttpNotFound();
            }
            return View(imageGalleryModel);
        }

        // POST: ImageGallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ImageGalleryModel imageGalleryModel = db.ImageGallery.Find(id);
            db.ImageGallery.Remove(imageGalleryModel);
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

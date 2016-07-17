using System;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ImageGalleryController : Controller
    {
        // GET: ImageGallery
        public ActionResult Index()
        {
            var db = new ImageDbConnectionContext();

            var imagesModel = new ImageGalleryModel();
            var imageFiles = Directory.GetFiles(Server.MapPath("~/Images/"));
            foreach (var item in imageFiles)
            {
                imagesModel.ImageList.Add(Path.GetFileName(item));
            }
            return View(imagesModel);

        }

        // GET: ImageGallery/Details
        public ActionResult Details(Guid? id)
        {
            var db = new ImageDbConnectionContext();

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
        public ActionResult Create([Bind(Include = "ID,Name,ImageToUpload,ImagePath")] ImageGalleryModel imageGalleryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                    {
                        var set = db.ImageGallery;
                        if (ModelState.IsValid)
                        {
                            imageGalleryModel.ID = Guid.NewGuid();
                            set.Add(imageGalleryModel);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return View(imageGalleryModel);
        }

        // GET: ImageGallery/Edit
        public ActionResult Edit(Guid? id)
        {
            var db = new ImageDbConnectionContext();

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

        // POST: ImageGallery/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ImagePath")] ImageGalleryModel imageGalleryModel)
        {
            var db = new ImageDbConnectionContext();

            if (ModelState.IsValid)
            {
                db.Entry(imageGalleryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imageGalleryModel);
        }

        // GET: ImageGallery/Delete
        public ActionResult Delete(Guid? id)
        {
            var db = new ImageDbConnectionContext();

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

        // POST: ImageGallery/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var db = new ImageDbConnectionContext();

            ImageGalleryModel imageGalleryModel = db.ImageGallery.Find(id);
            db.ImageGallery.Remove(imageGalleryModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

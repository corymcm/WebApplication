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
            if (ModelState.IsValid)
            {
                var imagesModel = new ImageGalleryModel();
                var imageFiles = Directory.GetFiles(Server.MapPath("~/Images/"));
                foreach (var item in imageFiles)
                {
                    imagesModel.ImageList.Add(new LocalImageModel(Path.GetFileName(item)));
                }

                return View(imagesModel);
            }
            return View();
        }

        // GET: ImageGallery/Details
        public ActionResult Details(Guid? id)
        {
            if (ModelState.IsValid)
            {
                using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    IImageModel image = db.ImageGallery.Find(id);
                    if (image == null)
                    {
                        return HttpNotFound();
                    }
                    return View(image);

                }
            }
            return View("Index");
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
        public ActionResult Create([Bind(Include = "Name,ImageToUpload")] UploadImageModel image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                    {
                        var set = db.ImageGallery;
                        image.ID = Guid.NewGuid();
                        using (Stream inputStream = image.ImageToUpload.InputStream)
                        {
                            MemoryStream memoryStream = inputStream as MemoryStream;
                            if (memoryStream == null)
                            {
                                memoryStream = new MemoryStream();
                                inputStream.CopyTo(memoryStream);
                            }
                            image.Data = memoryStream.ToArray();
                        }
                        set.Add(image);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            return View(image);
        }

        // GET: ImageGallery/Edit
        public ActionResult Edit(Guid? id)
        {
            if (ModelState.IsValid)
            {
                using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    IImageModel imageGalleryModel = db.ImageGallery.Find(id);
                    if (imageGalleryModel == null)
                    {
                        return HttpNotFound();
                    }
                    return View(imageGalleryModel);
                }
            }
            return View();
        }

        // POST: ImageGallery/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Data")] IImageModel imageGalleryModel)
        {
            if (ModelState.IsValid)
            {
                using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(imageGalleryModel).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(imageGalleryModel);
                }
            }
            return View();
        }

        // GET: ImageGallery/Delete
        public ActionResult Delete(Guid? id)
        {
            if (ModelState.IsValid)
            {
                using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    IImageModel imageGalleryModel = db.ImageGallery.Find(id);
                    if (imageGalleryModel == null)
                    {
                        return HttpNotFound();
                    }
                    return View(imageGalleryModel);
                }
            }
            return View();
        }

        // POST: ImageGallery/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            if (ModelState.IsValid)
            {
                using (ImageDbConnectionContext db = new ImageDbConnectionContext())
                {
                    UploadImageModel imageGalleryModel = db.ImageGallery.Find(id);
                    db.ImageGallery.Remove(imageGalleryModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}

using System.IO;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeModel = new HomeModel();
            homeModel.HomePicture = new LocalImageModel(Path.GetFileName("Images/20160827_204629.jpg"));
            return View(homeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Packages()
        {
            ViewBag.Message = "Packages";

            return View();
        }

        public ActionResult Reservations()
        {
            ViewBag.Message = "Reservations";

            return View();
        }

        public ActionResult Casas()
        {
            ViewBag.Message = "Houses for Rent";

            if (ModelState.IsValid)
            {
                var imagesModel = new ImageGalleryModel();
                var imageFiles = Directory.GetFiles(Server.MapPath("~/Casa/"));
                foreach (var item in imageFiles)
                {
                    imagesModel.ImageList.Add(new LocalImageModel(Path.GetFileName(item)));
                }

                return View(imagesModel);
            }
            return View();
        }
    }
}
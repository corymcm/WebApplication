using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Casas()
        {
            ViewBag.Message = "Houses for Rent";

            return View();
        }

        public ActionResult Images()
        {
            ViewBag.Message = "Image Gallery";

            return View();
        }
    }
}
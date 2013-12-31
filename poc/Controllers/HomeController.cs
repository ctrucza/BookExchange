using System.Web.Mvc;
using poc.Views.Home;

namespace poc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model =  new HomeViewModel();
            return View(model);
        }

        public ActionResult AllBooks()
        {
            ViewBag.Message = "List of all shared books";

            return View();
        }

        public ActionResult GiveAway()
        {
            ViewBag.Message = "Give your books away!";
            return View();
        }
    }
}
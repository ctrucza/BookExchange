using System.Web.Mvc;
using poc.Models;
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
    }
}
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

        public ActionResult AllBooks()
        {
            ViewBag.Message = "List of all shared books";

            return View();
        }

        [HttpGet]
        public ActionResult GiveAway()
        {
            ViewBag.Message = "Give your books away!";
            return View();
        }

        [HttpPost]
        public ActionResult GiveAway(Book book)
        {
            BookRepository.AddNewBook(book, User.Identity.Name);
            return RedirectToAction("GiveAway");
        }
    }
}
using System.Net;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
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
            return View();
        }

        public ActionResult AllUsers()
        {
            return View();
        }

        public ActionResult YourBooks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GiveAway()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiveAway(Book book)
        {
            BookRepository.AddNewBook(book, User.Identity.Name);
            return RedirectToAction("GiveAway");
        }

        public ActionResult UsersBooks(string userName)
        {
            return View(userName);
        }
    }
}
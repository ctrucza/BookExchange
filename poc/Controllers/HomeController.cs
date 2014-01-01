using System.Web.Mvc;
using poc.Models;

namespace poc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
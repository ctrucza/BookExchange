using System.Collections.Generic;
using poc.Models;

namespace poc.Views.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Book> RecentBooks { get { return BookRepository.GetRecentBooks(); } }
        public IEnumerable<User> TopSharers { get { return UserRepository.GetTopSharers(); } }
    }
}
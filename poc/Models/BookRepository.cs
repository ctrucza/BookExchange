using System.Collections.Generic;
using System.Linq;

namespace poc.Models
{
    public static class BookRepository
    {
        public static IEnumerable<Book> GetAllBooks()
        {
            return DAL.Books();
        }

        public static IEnumerable<Book> GetRecentBooks()
        {
            return GetAllBooks().Take(12);
        }

        public static void AddNewBook(Book book, string username)
        {
            User user = DAL.Users().SingleOrDefault(u => u.Name == username);
            if(user == null)
            {
                user = new User
                {
                    Name = username
                };
                DAL.AddUser(user);
            }
            book.SharedBy = user;
            DAL.AddBook(book);
        }

        public static IEnumerable<Book> GetUsersBooks(string userName)
        {
            return GetAllBooks().Where(b => b.SharedBy.Name == userName);
        }
    }
}
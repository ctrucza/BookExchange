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

        public static void AddNewBook(Book book, string username)
        {
            User user = DAL.Users().SingleOrDefault(u => u.Name == username);
            if(user == null)
            {
                user = new User
                {
                    Name = username,
                    Books = new List<Book>()
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

        public static IEnumerable<Book> Search(string searchTerm)
        {
            IEnumerable<Book> result = GetAllBooks().Where( book =>
                    book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm)
                );
            return result;
        }
    }
}
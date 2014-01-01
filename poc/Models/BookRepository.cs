using System.Collections.Generic;
using System.Linq;

namespace poc.Models
{
    public static class BookRepository
    {
        private static List<Book> currentUsersBooks = new List<Book>();
        private static List<Book> allBooks = new List<Book>();

        public static IEnumerable<Book> GetAllBooks()
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < 100; ++i)
            {
                result.Add(new Book
                {
                    Author = "Author " + i,
                    Title = "Title " + i,
                    SharedBy = UserRepository.GetRandomUser()
                });
            }
            return result;
        }

        public static IEnumerable<Book> GetRecentBooks()
        {
            return GetAllBooks().Take(12);
        }

        public static void AddNewBook(Book book, string username)
        {
            book.SharedBy = new User
            {
                Name = username,
                SharedBooksCount = currentUsersBooks.Count + 1
            };
            currentUsersBooks.Add(book);
        }

        public static IEnumerable<Book> GetMyBooks()
        {
            // TODO: use GetUsersBooks
            return currentUsersBooks;
        }

        public static IEnumerable<Book> GetUsersBooks(string userName)
        {
            return GetAllBooks().Where(b => b.SharedBy.Name == userName);
        }
    }
}
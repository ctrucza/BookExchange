using System.Collections.Generic;

namespace poc.Models
{
    public static class BookRepository
    {
        private static List<Book> currentUsersBooks = new List<Book>(); 
        public static IEnumerable<Book> GetRecentBooks()
        {
            List<Book> result = new List<Book>();
            for(int i = 0; i < 10; ++i)
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
            return currentUsersBooks;
        }
    }
}
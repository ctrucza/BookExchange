using System.Collections.Generic;

namespace poc.Models
{
    public static class DAL
    {
        private static IStorage storage;

        public static IEnumerable<Book> Books()
        {
            return storage.StorageFor<Book>();
        } 

        public static void AddBook(Book book)
        {
            storage.Add(book);
        }

        public static void AddUser(User user)
        {
            storage.Add(user);
        }

        public static IEnumerable<User> Users()
        {
            return storage.StorageFor<User>();
        }

        public static void SetStorage(IStorage aStorage)
        {
            storage = aStorage;
        }
    }
}
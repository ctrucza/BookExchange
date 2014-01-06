using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace poc.Models
{
    public class MockStorage : IStorage
    {
        public MockStorage()
        {
            if (!StorageFor<User>().Any())
                AddUsers();
        
            if(!StorageFor<Book>().Any())
                AddBooks();
        }


        private void AddUsers()
        {
            for (int i = 0; i < 30; ++i)
            {
                Add(CreateRandomUser());
            }
        }

        private readonly Random random = new Random();
        private User CreateRandomUser()
        {
            return new User
            {
                Name = "Random user " + random.Next(50),
                Books = new List<Book>()
            };
        }

        private User GetRandomUser()
        {
            int count = StorageFor<User>().Count();
            int index = random.Next(count);
            User result = null;
            while(result == null)
                result = StorageFor<User>().Skip(index).Take(1).SingleOrDefault();
            return result;
        }


        private void AddBooks()
        {
            for(int i = 0; i < 100; ++i)
            {
                User user = GetRandomUser();

                Book book = new Book
                {
                    Author = "Random author " + random.Next(50),
                    Title = "Random title " + random.Next(50),
                    SharedBy = user
                };

                Add(book);
                user.Books.Add(book);
            }
        }

        private static readonly Dictionary<Type, IList> lists = new Dictionary<Type, IList>();

        public IQueryable<T> StorageFor<T>() where T : class
        {
            return GetList<T>().AsQueryable();
        }

        private IList<T> GetList<T>()
        {
            if (!lists.ContainsKey(typeof(T)))
            {
                lists.Add(typeof(T), new List<T>());
            }
            return lists[typeof(T)] as IList<T>;
        }
        
        public void Add<T>(T entity) where T : class
        {
            IList<T> table = GetList<T>();
            table.Add(entity);
        }
    }
}
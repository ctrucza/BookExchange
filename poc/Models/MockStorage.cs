﻿using System;
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
                SharedBooksCount = 42 + random.Next(50)
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
                Book book = new Book
                {
                    Author = "Random author " + random.Next(50),
                    Title = "Random title " + random.Next(50),
                    SharedBy = GetRandomUser()
                };
                Add(book);
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
        
        public T Add<T>(T entity) where T : class
        {
            IList<T> table = GetList<T>();
            table.Add(entity);
            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
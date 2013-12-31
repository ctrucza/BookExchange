using System;
using System.Collections.Generic;

namespace poc.Models
{
    public static class UserRepository
    {
        public static IEnumerable<User> GetTopSharers()
        {
            List<User> result = new List<User>();
            for (int i = 0; i < 12; ++i )
            {
                result.Add(GetRandomUser());
            }
            return result;
        }

        private static readonly Random random = new Random();
        public static User GetRandomUser()
        {
            return new User
            {
                Name = "Random user " + random.Next(50), 
                SharedBooksCount = 42 + random.Next(50)
            };
        }

        public static IEnumerable<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            for (int i = 0; i < 30; ++i)
            {
                result.Add(GetRandomUser());
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;

namespace poc.Models
{
    public class UserRepository
    {
        public static IEnumerable<User> GetTopSharers()
        {
            List<User> result = new List<User>();
            for (int i = 0; i < 10; ++i )
            {
                result.Add(GetRandomUser());
            }
                return result;
        }

        private static Random random = new Random();
        public static User GetRandomUser()
        {
            return new User
            {
                Name = "Random user " + random.Next(50), 
                SharedBooksCount = 42 + random.Next(50)
            };
        }
    }
}
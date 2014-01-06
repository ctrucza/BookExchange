using System.Collections.Generic;

namespace poc.Models
{
    public static class UserRepository
    {
        public static IEnumerable<User> GetAllUsers()
        {
            return DAL.Users();
        }
    }
}
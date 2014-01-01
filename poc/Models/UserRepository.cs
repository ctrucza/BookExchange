using System.Collections.Generic;
using System.Linq;

namespace poc.Models
{
    public static class UserRepository
    {
        public static IEnumerable<User> GetTopSharers()
        {
            return DAL.Users().Take(12);
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return DAL.Users();
        }
    }
}
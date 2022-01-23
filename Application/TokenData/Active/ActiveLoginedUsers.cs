using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TokenData.Active
{
    public class ActiveLoginedUsers
    {
        private static readonly ISet<LoginedUser> AllActiveUsers = new HashSet<LoginedUser>();

        public void addUser(LoginedUser user)
        {
            AllActiveUsers.Add(user);
        }

        public IEnumerable<LoginedUser> GetAllLoginedUsers()
        {
            return AllActiveUsers;
        }
    }
}

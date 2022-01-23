using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TokenData.Active
{
    public class ActiveLoginedUsers
    {
        private static List<LoginedUser> AllActiveUsers {get;set;}

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

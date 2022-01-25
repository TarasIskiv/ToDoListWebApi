using System.Collections.Generic;


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

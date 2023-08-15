using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        public static bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryStudents = context.Users;
            int countStudents = queryStudents.Count();
            return countStudents == 0 ? true : false;
        }

        public static void CopyUsersToDb()
        {
            UserContext context = new UserContext();
            foreach (User user in TestUsers) 
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }

        static private void ResetTestUserData()
        {

            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);

                _testUsers.Add(new User());
                _testUsers[0].UserName = "ADMIN";
                _testUsers[0].Password = "123456";
                _testUsers[0].FacNum = "888888888";
                _testUsers[0].Role = 1;
                _testUsers[0].dateCreated = DateTime.Now;
                _testUsers[0].validity = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[1].UserName = "Ivan Tomchev";
                _testUsers[1].Password = "wordpass2";
                _testUsers[1].FacNum = "121219112";
                _testUsers[1].Role = 2;
                _testUsers[1].dateCreated = DateTime.Now;
                _testUsers[1].validity = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[2].UserName = "Boris Petrov";
                _testUsers[2].Password = "wordpass1";
                _testUsers[2].FacNum = "121219888";
                _testUsers[2].Role = 2;
                _testUsers[2].dateCreated = DateTime.Now;
                _testUsers[2].validity = DateTime.MaxValue;
            }
        }

        static public User IsUserPassCorrect(string user, string pass)
        {
            UserContext context= new UserContext();
            User login = (from u in context.Users where u.UserName == user && u.Password == pass select u).First();

            if (login != null)
                return login;
            return null;
        }

        static public void SetUserActiveTo(string username, DateTime newDate)
        {
            foreach (User u in _testUsers)
            {
                if (u.UserName == username)
                {
                    u.validity = newDate;
                    Logger.LogActivity("Activity date changed of user: " + username);
                }
            }
        }

        static public void AssignUserRole(string username, int newRole)
        {
            UserContext context= new UserContext();
            User usr = (from u in TestUsers where u.UserName == username select u).First();
            usr.Role = newRole;
            Logger.LogActivity("Role changed of user: " + username);
                

        }
    }
}
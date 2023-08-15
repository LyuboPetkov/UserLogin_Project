using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        static public string userName
        {
            get; private set;
        }
        static public string password
        {
            get; private set;
        }

        private string ErrorMessage;

        public delegate void ActionOnError(string _errorMessage);

        private ActionOnError _onError;

        public LoginValidation(string user, string pass, ActionOnError error)
        {
            userName = user;
            password = pass;
            _onError = error;
        }

        static public UserRoles currentUserRole { get; private set; }
        public bool ValidateUserInput(ref User user)
        {
            User newUser = new User();

            if (userName.Equals(String.Empty))
            {
                ErrorMessage = "No username input.";
                _onError(ErrorMessage);
                return false;
            }
            if (password.Equals(String.Empty))
            {
                ErrorMessage = "No password input.";
                _onError(ErrorMessage);
                return false;
            }
            if (userName.Length < 5)
            {
                ErrorMessage = "Username too short. It should be longer than five symbols.";
                _onError(ErrorMessage);

                return false;
            }
            if (password.Length < 5)
            {
                ErrorMessage = "Password too short. It should be longer than five symbols.";
                _onError(ErrorMessage);

                return false;
            }
            if (UserData.IsUserPassCorrect(userName, password) != null)
            {
                newUser = UserData.IsUserPassCorrect(userName, password);
                user = newUser;
                currentUserRole = (UserRoles)user.Role;
                Logger.LogActivity("Login successful!");
                return true;
            }
            ErrorMessage = "Problem with login information.";
            currentUserRole = (UserRoles)0;
            return false;
        }
    }
}
using Bank.DAL;
using System;
using System.Security.Authentication;

namespace Bank
{
    public class UserHandler
    {
        private IUser _currentUser;

        public IUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    throw new InvalidCredentialException();
                }
                return _currentUser;
            }
        }

        public bool Login(string pin)
        {
            UserDAL dal = new UserDAL();

            IUser user = dal.GetAll().Find(x => x.Pin == pin);

            return AssignUser(user);
        }

        public  bool IsCurrentUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public bool LoggedIn()
        {
            if(_currentUser != null)
            {
                return true;
            }
            return false;
        }

        public bool ValidateUser(IUser user)
        {
            throw new NotImplementedException();
        }

        private bool AssignUser(IUser user)
        {
            if (user != null)
            {
                _currentUser = user;
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL
{
    class UserDAL
    {
        private List<IUser> users;

        public UserDAL()
        {
            List<IUser> userList = new List<IUser>();

            userList.Add(new User("1234"));
            userList.Add(new User("4321"));
            userList.Add(new User("5678"));

            foreach (IUser user in userList)
            {

                user.AddAccount("Main Account");
                this.users.Add(user);
            }

        }

        public List<IUser> GetAll()
        {
            return this.users;
        }
    }
}

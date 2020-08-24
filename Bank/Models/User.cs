using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class User: IUser
    {
        public string Pin { get; private set; }
        public List<Account> Accounts { get; private set; }

        public User(string pin)
        {
            this.Pin = pin;
            this.Accounts = new List<Account>();
        }

        public void AddAccount(string name)
        {
            Account newAccount = new Account(name, this, 0);
            this.Accounts.Add(newAccount);
        }
    }
}

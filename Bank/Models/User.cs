using Bank.Classes;
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
        public Account Account { get; private set; }

        public User(string pin)
        {
            this.Pin = pin;
            this.Account = new Account("Standard", this, StaticRandom.Rand(100000));
        }
    }
}

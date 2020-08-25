using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        public string Name { get; private set; }
        public IUser OwnedBy { get; private set; }
        public decimal Balance { get; set; }

        public Account(string name, IUser ownedBy, decimal balance)
        {
            Name = name;
            OwnedBy = ownedBy;
            Balance = balance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    interface IUser
    {
        string Pin { get; }
        List<Account> Accounts{ get; }

        void AddAccount(string name);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class BankHandler
    {

        public static void AddToBalance(IUser user, decimal amount)
        {
            if(user == null)
            {
                throw new AuthenticationException();
            }

            if(amount <= 0)
            {
                throw new InvalidOperationException();
            }

            user.Account.Balance += amount;
        }

        public static void WithdrawFromBalance(IUser user, decimal amount)
        {
            if (user == null)
            {
                throw new ArgumentException("User is null", "user");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount is below 0", "amount");
            }

            if (user.Account.Balance < amount)
            {
                throw new ArgumentException("The withdrawel amount is larger than the current balance.", "amount");
            }

            user.Account.Balance -= amount;

        }

        public static decimal ShowBalance(IUser user)
        {
            if (user == null)
            {
                throw new AuthenticationException();
            }

            decimal balance = user.Account.Balance;
            return balance;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface IUser
    {
        string Pin { get; }
        Account Account{ get; }

    }
}

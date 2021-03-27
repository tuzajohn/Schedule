using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScheduler.Models.Interfaces
{
    interface IAccount
    {
        (Account account, string message, bool check) Get(string id);
        (IEnumerable<Account> accounts, string message, bool check) Get();
        (Account account, string message, bool check) Update(Account account);
        (string message, bool check) Delete(Account account);
        (Account account, string message, bool check) Add(Account account);

    }
}

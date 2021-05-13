using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWebApi.Models.Interfaces
{
    public interface IUser
    {
        (User user, string message, bool check) Add(User user);
        (User user, string message, bool check) Update(User user);
        (string message, bool check) Delete(User user);

        (User user, string message, bool check) Get(string id);
        (IEnumerable<User> users, string message, bool check) Get();
    }
}

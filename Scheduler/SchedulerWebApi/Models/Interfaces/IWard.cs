using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerWebApi.Models.Interfaces
{
    public interface IWard
    {
        (Ward ward, string message, bool check) Add(Ward ward);
        (Ward ward, string message, bool check) Get(string id);
        (Ward ward, string message, bool check) Update(Ward ward);
        (IEnumerable<Ward> wards, string message, bool check) Get();
        (string message, bool check) Delete(Ward ward);
    }
}

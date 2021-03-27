using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScheduler.Models.Interfaces
{
    interface IDivision
    {
        (Division division, string message, bool check) Get(string id);
        (IEnumerable<Ward> wards, string message, bool check) GetWard(string id);
        (IEnumerable<Division> divisions, string message, bool check) Get();
        (Division division, string message, bool check) Update(Division division);
        (string message, bool check) Delete(string id);
        (Division division, string message, bool check) Add(Division division);
    }
}

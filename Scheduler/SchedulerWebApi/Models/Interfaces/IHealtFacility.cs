using System.Collections.Generic;

namespace SchedulerWebApi.Models.Interfaces
{
    public interface IHealtFacility
    {
        (HealthCenter healthCenter, string message, bool check) Get(string id);
        (IEnumerable<HealthCenter> healthCenters, string message, bool check) Get();
        (HealthCenter healthCenter, string message, bool check) Update(HealthCenter healthCenter);
        (string message, bool check) Delete(string id);
        (HealthCenter healthCenter, string message, bool check) Add(HealthCenter healthCenter);
    }
}

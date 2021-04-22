using System.Collections.Generic;

namespace SchedulerWebApi.Models.Interfaces
{
    public interface IShift
    {
        (Shift shift, string message, bool check) Add(Shift shift);
        (Shift shift, string message, bool check) Get(string id);
        (Shift shift, string message, bool check) GetByDate(string id, string userId);
        (IEnumerable<Shift> shifts, string message, bool check) GetByUserId(string id);
        (IEnumerable<Shift> shifts, string message, bool check) GetByWardId(string id);
        (IEnumerable<Shift> shifts, string message, bool check) Get();
        (Shift shift, string message, bool check) Update(string id, Shift shift);
        (string message, bool check) Delete(string id);
        (string message, bool check) DeleteRange(IEnumerable<Shift> shifts);
    }
    public interface IHistoryShift
    {
        (HistoryShift historyShift, string message, bool check) Add(Shift _shift);
        (HistoryShift historyShift, string message, bool check) Get(string id);
        (HistoryShift historyShift, string message, bool check) GetByUserId(string id);
        (HistoryShift historyShift, string message, bool check) GetByWardId(string id);
        (IEnumerable<HistoryShift> historyShifts, string message, bool check) Get();
        (HistoryShift historyShift, string message, bool check) Update(string id, HistoryShift historyShift);
        (string message, bool check) Delete(string id);
    }
}

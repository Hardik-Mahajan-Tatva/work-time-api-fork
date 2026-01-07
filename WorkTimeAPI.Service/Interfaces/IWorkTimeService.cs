using WorkTimeAPI.Repository.Models;

namespace WorkTimeAPI.Service.Interfaces;

public interface IWorkTimeService
{
    Task<List<DailyWorkLog>> GetCurrentMonthAsync(int userId);
}

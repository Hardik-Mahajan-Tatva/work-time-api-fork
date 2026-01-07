using WorkTimeAPI.Repository.Models;

namespace WorkTimeAPI.Repository.Interfaces;

public interface IWorkTimeRepository
{
    Task<List<DailyWorkLog>> GetCurrentMonthLogsAsync(int userId);
}

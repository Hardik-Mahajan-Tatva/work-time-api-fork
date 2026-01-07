using Microsoft.EntityFrameworkCore;
using WorkTimeAPI.Repository.Interfaces;
using WorkTimeAPI.Repository.Models;

namespace WorkTimeAPI.Repository.Implementations;

public class WorkTimeRepository(WorkLogContext context) : IWorkTimeRepository
{
    private readonly WorkLogContext _context = context;

    public async Task<List<DailyWorkLog>> GetCurrentMonthLogsAsync(int userId)
    {
        DateTime now = DateTime.UtcNow;

        return await _context.DailyWorkLogs
            .Where(x =>
                x.UserId == userId &&
                x.WorkDate.Year == now.Year &&
                x.WorkDate.Month == now.Month
            )
            .OrderBy(x => x.WorkDate)
            .AsNoTracking()
            .ToListAsync();
    }
}

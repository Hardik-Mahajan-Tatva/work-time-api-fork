using WorkTimeAPI.Repository.Interfaces;
using WorkTimeAPI.Repository.Models;
using WorkTimeAPI.Service.Interfaces;

namespace WorkTimeAPI.Service.Implementations;

public class WorkTimeService(IWorkTimeRepository repository) : IWorkTimeService
{
    private readonly IWorkTimeRepository _repository = repository;

    public Task<List<DailyWorkLog>> GetCurrentMonthAsync(int userId)
        => _repository.GetCurrentMonthLogsAsync(userId);
}

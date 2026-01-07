using Microsoft.AspNetCore.Mvc;
using WorkTimeAPI.Service.Interfaces;

namespace WorkTimeAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkTimeController(IWorkTimeService workTimeService) : ControllerBase
{
    private readonly IWorkTimeService _workTimeService = workTimeService;

    [HttpGet("current-month/{userId:long}")]
    public async Task<IActionResult> GetCurrentMonth(int userId)
    {
        List<Repository.Models.DailyWorkLog>? dailyWorkLogs = await _workTimeService.GetCurrentMonthAsync(userId);
        return Ok(dailyWorkLogs);
    }
}

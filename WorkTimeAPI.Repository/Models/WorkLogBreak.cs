namespace WorkTimeAPI.Repository.Models;

public partial class WorkLogBreak
{
    public long BreakId { get; set; }

    public long WorkLogId { get; set; }

    public string? BreakName { get; set; }

    public DateTime BreakStart { get; set; }

    public DateTime? BreakEnd { get; set; }

    public int? BreakMinutes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual DailyWorkLog WorkLog { get; set; } = null!;
}

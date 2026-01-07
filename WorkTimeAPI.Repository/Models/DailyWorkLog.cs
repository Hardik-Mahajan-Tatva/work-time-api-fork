namespace WorkTimeAPI.Repository.Models;

public partial class DailyWorkLog
{
    public long WorkLogId { get; set; }

    public long UserId { get; set; }

    public DateOnly WorkDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? LastActiveTime { get; set; }

    public int? TotalWorkMinutes { get; set; }

    public int? TotalBreakMinutes { get; set; }

    public bool? IsClosed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DailyInOutLog> DailyInOutLogs { get; set; } = new List<DailyInOutLog>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkLogBreak> WorkLogBreaks { get; set; } = new List<WorkLogBreak>();
}

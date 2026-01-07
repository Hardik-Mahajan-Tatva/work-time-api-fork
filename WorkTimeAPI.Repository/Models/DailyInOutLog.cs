namespace WorkTimeAPI.Repository.Models;

public partial class DailyInOutLog
{
    public long DailyInOutId { get; set; }

    public long WorkLogId { get; set; }

    public DateTime TimeIn { get; set; }

    public DateTime? TimeOut { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual DailyWorkLog WorkLog { get; set; } = null!;
}

namespace WorkTimeAPI.Repository.Models;

public partial class User
{
    public long UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<DailyWorkLog> DailyWorkLogs { get; set; } = new List<DailyWorkLog>();
}

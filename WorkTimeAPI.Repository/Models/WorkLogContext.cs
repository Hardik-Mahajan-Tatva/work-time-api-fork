using Microsoft.EntityFrameworkCore;

namespace WorkTimeAPI.Repository.Models;

public partial class WorkLogContext : DbContext
{
    public WorkLogContext(DbContextOptions<WorkLogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailyInOutLog> DailyInOutLogs { get; set; }

    public virtual DbSet<DailyWorkLog> DailyWorkLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkLogBreak> WorkLogBreaks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DailyInOutLog>(entity =>
        {
            entity.HasKey(e => e.DailyInOutId).HasName("daily_in_out_logs_pkey");

            entity.ToTable("daily_in_out_logs");

            entity.Property(e => e.DailyInOutId).HasColumnName("daily_in_out_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TimeIn)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_in");
            entity.Property(e => e.TimeOut)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("time_out");
            entity.Property(e => e.WorkLogId).HasColumnName("work_log_id");

            entity.HasOne(d => d.WorkLog).WithMany(p => p.DailyInOutLogs)
                .HasForeignKey(d => d.WorkLogId)
                .HasConstraintName("fk_inout_worklog");
        });

        modelBuilder.Entity<DailyWorkLog>(entity =>
        {
            entity.HasKey(e => e.WorkLogId).HasName("daily_work_logs_pkey");

            entity.ToTable("daily_work_logs");

            entity.HasIndex(e => new { e.UserId, e.WorkDate }, "uq_user_workdate").IsUnique();

            entity.Property(e => e.WorkLogId).HasColumnName("work_log_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.IsClosed)
                .HasDefaultValue(false)
                .HasColumnName("is_closed");
            entity.Property(e => e.LastActiveTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_active_time");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.TotalBreakMinutes)
                .HasDefaultValue(0)
                .HasColumnName("total_break_minutes");
            entity.Property(e => e.TotalWorkMinutes)
                .HasDefaultValue(0)
                .HasColumnName("total_work_minutes");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WorkDate).HasColumnName("work_date");

            entity.HasOne(d => d.User).WithMany(p => p.DailyWorkLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_worklog_user");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
        });

        modelBuilder.Entity<WorkLogBreak>(entity =>
        {
            entity.HasKey(e => e.BreakId).HasName("work_log_breaks_pkey");

            entity.ToTable("work_log_breaks");

            entity.Property(e => e.BreakId).HasColumnName("break_id");
            entity.Property(e => e.BreakEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("break_end");
            entity.Property(e => e.BreakMinutes)
                .HasDefaultValue(0)
                .HasColumnName("break_minutes");
            entity.Property(e => e.BreakName)
                .HasMaxLength(100)
                .HasColumnName("break_name");
            entity.Property(e => e.BreakStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("break_start");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.WorkLogId).HasColumnName("work_log_id");

            entity.HasOne(d => d.WorkLog).WithMany(p => p.WorkLogBreaks)
                .HasForeignKey(d => d.WorkLogId)
                .HasConstraintName("fk_break_worklog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

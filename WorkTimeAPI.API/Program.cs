using Microsoft.EntityFrameworkCore;
using WorkTimeAPI.Repository.Implementations;
using WorkTimeAPI.Repository.Interfaces;
using WorkTimeAPI.Repository.Models;
using WorkTimeAPI.Service.Implementations;
using WorkTimeAPI.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Connection string name and contect as per that name
builder.Services.AddDbContext<WorkLogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RemoteConnection"))
);

builder.Services.AddScoped<IWorkTimeRepository, WorkTimeRepository>();
builder.Services.AddScoped<IWorkTimeService, WorkTimeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();

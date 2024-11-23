using Hangfire;
using Microsoft.EntityFrameworkCore;
using StudentiBackup_BGJobs;
using StudentiBackup_BGJobs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDbContext>(
    opt => opt.UseSqlServer("Server=localhost;Database=bgjobsstudent;Trusted_Connection=True;Encrypt=False;")
);

builder.Services.AddHangfire(conf =>
{
    conf.UseSqlServerStorage("Server=localhost;Database=bgjobsstudent;Trusted_Connection=True;Encrypt=False;");
    conf.UseSimpleAssemblyNameTypeSerializer();
    conf.UseRecommendedSerializerSettings();
});

builder.Services.AddHangfireServer();
builder.Services.AddTransient<IStudentBackupService, StudentBackupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IStudentBackupService>(x => x.Run(), Cron.Daily);

app.Run();

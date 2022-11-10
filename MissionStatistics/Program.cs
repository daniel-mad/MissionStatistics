using Microsoft.EntityFrameworkCore;
using MissionStatistics.Application.Services;
using MissionStatistics.Data.DbContexts;
using MissionStatistics.Data.Reositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MissionStatisticsDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnectionString"))
    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information)
    .EnableSensitiveDataLogging();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddTransient<IMissionRepository, MissionRepository>();
builder.Services.AddSingleton<IGeocodingService, GeocodingService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

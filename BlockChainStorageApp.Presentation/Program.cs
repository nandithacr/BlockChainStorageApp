using BlockChainStorageApp.External;
using BlockChainStorageApp.Data.Data;
using BlockChainStorageApp.Core;
using BlockChainStorageApp.Core.Interfaces;
using BlockChainStorageApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using BlockChainStorageApp.External.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); 
}

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddSingleton<FileLogger>();
builder.Services.AddLogging(logging =>
{
    logging.AddProvider(new FileLoggerProvider("logs/app-log.txt"));
});

builder.Services.AddScoped<ICryptoRepository, CryptoRepository>();

// Enable CORS for all origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();

//Make Program.cs file visible to test projects
public partial class Program { }
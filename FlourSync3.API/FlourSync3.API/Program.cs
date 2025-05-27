using FlourSync3.API.Data;
using Microsoft.EntityFrameworkCore; // Importing EF Core for database context and configuration

var builder = WebApplication.CreateBuilder(args);

//connect to the database using the connection string from appsettings.json
builder.Services.AddDbContext<FlourSyncContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 42)) // Specify the MySQL version you are using, e.g., 8.0.42
    )
   );

// Add services to the container.

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

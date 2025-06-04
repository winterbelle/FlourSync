using FlourSync3.API.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore; // Importing EF Core for database context and configuration


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to the database using the connection string from appsettings.json
builder.Services.AddDbContext<FlourSyncContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 42)) // Specify the MySQL version you are using, e.g., 8.0.42
    )
);

//Cors Policy Defined
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") //replace with frontend dev server, if not 3000.
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

//use CORS
app.UseCors(MyAllowSpecificOrigins);
                         
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FlourSyncContext>();
    var env = services.GetRequiredService<IWebHostEnvironment>();

    if (env.IsDevelopment())
    { //only run this in development environment
        await SeedData.InitializeAsync(context); // ? this line is everything
    }

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var logger = context.RequestServices
            .GetRequiredService<ILogger<Program>>();

        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerPathFeature>();
        if (error != null)
        {
            logger.LogError(error.Error, "An unhandled exception occurred: {Path}", error.Path);
            await context.Response.WriteAsync("{\"error\": \"Something went wrong. Our pastries are crying.\"}");
        }
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

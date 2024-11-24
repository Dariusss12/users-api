using Microsoft.EntityFrameworkCore;
using users_api.Src.Data;
using users_api.Src.Repositories;
using users_api.Src.Repositories.interfaces;
using users_api.Src.Services;
using users_api.Src.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite("Data Source=EVSUM4.db"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<DataContext>();

    DataSeeder.Initialize(services);
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


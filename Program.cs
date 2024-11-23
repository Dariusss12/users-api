using Microsoft.EntityFrameworkCore;
using users_api.Src.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlite("Data Source=EVSUM4.db"));

var app = builder.Build();


app.UseHttpsRedirection();

app.Run();


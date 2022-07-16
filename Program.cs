using EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasBD"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+ dbContext.Database.IsInMemory());
});

app.Run();

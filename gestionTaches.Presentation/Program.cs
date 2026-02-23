using gestionTaches.Infrastructure;
using Microsoft.EntityFrameworkCore;
using gestionTaches.Application;
using gestionTaches.Presentation.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TachesDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TachesDBConnection"));
});

builder.Services.AddApplication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddTachesEndpoints();
app.Run();

//REQ =>>> MED ==> HANDLER =>> DB
//COMMANDS / QUERIES
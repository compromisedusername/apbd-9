using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseApp2.Middlewares;
using WebApplication1.Data;
using WebApplication1.Repositories;
using WebApplication1.Repositories.clients;
using WebApplication1.Services;
using WebApplication1.Services.clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ScaffoldContext>(options => options.UseSqlServer("Name=ConnectionStrings:Default"));
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<ITripsService, TripsService>();
builder.Services.AddScoped<ITripsRepository, TripsRepository>();
builder.Services.AddScoped <IUnitOfWork>(sp =>
{
    var context = sp.GetRequiredService<ScaffoldContext>();
    return new UnitOfWork(context);
});
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();


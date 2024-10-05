using Microsoft.EntityFrameworkCore;
using PeluqueriaBack.Data.Models;
using PeluqueriaBack.Data.Repositories.Contracts;
using PeluqueriaBack.Data.Repositories.Implementations;
using PeluqueriaBack.Services.Contracts;
using PeluqueriaBack.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PELUQUERIAContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));
builder.Services.AddScoped<ITTurnoRepository, TTurnoRepository>();
builder.Services.AddScoped<ITTurnoService, TTurnoService>();



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

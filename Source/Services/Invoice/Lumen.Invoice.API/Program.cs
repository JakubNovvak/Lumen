using Lumen.Invoice.Domain.Interfaces;
using Lumen.Invoice.Infrastructure.Presistence;
using Lumen.Invoice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Services Configuration

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine(">[EnvMode] Starting Application in Development Mode.");
    Console.WriteLine(">[DBConf] Using In Memory Database.");

    builder.Services.AddDbContext<InvoiceDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
}
else
{
    //TODO: SQL Server for Production
}

builder.Services.AddScoped<IInvoiceRepo, InvoiceRepo>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

#region App Configuration

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

InvoiceDbContextSeed.PrepPopulation(app, builder.Environment.IsProduction());

app.MapControllers();

app.Run();

#endregion
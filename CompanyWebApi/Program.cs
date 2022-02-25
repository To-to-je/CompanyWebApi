

using CompanyWebApi.Core;
using CompanyWebApi.Core.Domain;
using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using CompanyWebApi.Persistence;
using CompanyWebApi.Persistence.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationManager();




builder.Services.AddControllers();

// I do not like this magic strings, but do not know how to avoid it

configuration.AddJsonFile("appsettings.json");

var connectionString = configuration.GetValue<string>("ConnectionStrings:CustomersDatabase");



builder.Services.AddDbContext<CompanyContext>
    (opt => opt
        .UseSqlServer(connectionString));




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();



// Configure ,the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



using Concord.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var strConnection = Environment.GetEnvironmentVariable("SQLCONN");
builder.Services.AddDbContext<ConcordDbContext>(
    options => options.UseSqlServer(strConnection)
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

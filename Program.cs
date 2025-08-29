using Concord.Entities;
using Concord.Services.JWT;

using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Concord.UseCases.GetRoomDetail;
using Concord.UseCases.Auth;

var builder = WebApplication.CreateBuilder(args);

var strConnection = Environment.GetEnvironmentVariable("SQLCONN");
builder.Services.AddDbContext<ConcordDbContext>(
    options => options.UseSqlServer(strConnection)
);

builder.Services.AddSingleton<IJWTService, JWTService>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidIssuer = "concord",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = key,
        };
    });

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddTransient<AuthUseCase>();
builder.Services.AddTransient<GetRoomDetailUseCase>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();

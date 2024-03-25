using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContextPool<IdentityDbContext<IdentityUser>>(x =>
{
    x.UseInMemoryDatabase("data");
});

builder.Services
    .AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<IdentityDbContext<IdentityUser>>()
    .AddApiEndpoints();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

app.MapGet("/", (ClaimsPrincipal user) => user.Identity?.Name).RequireAuthorization();

app.Run();

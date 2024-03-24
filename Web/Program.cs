using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>>(options =>
{
    options.UseInMemoryDatabase("Database");
});

builder.Services
    .AddIdentityCore<IdentityUser<Guid>>(options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>>()
    .AddSignInManager<SignInManager<IdentityUser<Guid>>>();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme, options =>
    {
        options.SlidingExpiration = true;
    });

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthentication();

app.MapControllers();

await app.RunAsync();
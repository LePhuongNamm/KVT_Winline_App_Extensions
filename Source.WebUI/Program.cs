using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Source.Core.Contracts.Basic;
using Source.Infrastructure.Infralayer;
using Source.Infrastructure.Repositories.Basic;
using Source.WebUI.Components;
using Source.WebUI.Authentication;
using Tewr.Blazor.FileReader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddHubOptions(options =>
    {
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(180);
        options.HandshakeTimeout = TimeSpan.FromSeconds(90);
    });

builder.Services.AddScoped<IWrapperRepository, WrapperRepository>();
builder.Services.AddScoped<SqlConnectionFactory>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();
builder.Services.AddScoped<ICookieValidatorService, CookieValidatorService>();
builder.Services.AddFileReaderService();
builder.Services.AddCascadingAuthenticationState();
builder.Services
       .AddAuthentication(options =>
           {
               options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
               options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
           })
       .AddCookie(options =>
           {
               options.LoginPath = "/Account/Login";
               options.LogoutPath = "/Account/Logout";
               options.AccessDeniedPath = "/Account/Forbidden";
               options.Cookie.Name = ".KVTWL.Security.Cookie";
               options.ExpireTimeSpan = TimeSpan.FromDays(30);
               options.SlidingExpiration = true;
               options.Cookie.HttpOnly = true;
               options.Cookie.IsEssential = true;
               options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
               options.Cookie.SameSite = SameSiteMode.Lax;
               options.Events = new CookieAuthenticationEvents
               {
                   OnValidatePrincipal = context =>
                   {
                       var cookieValidatorService = context.HttpContext.RequestServices.GetRequiredService<ICookieValidatorService>();
                       return cookieValidatorService.ValidateAsync(context);
                   }
               };
           });

var app = builder.Build();

if (!app.Environment.IsDevelopment()) 
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

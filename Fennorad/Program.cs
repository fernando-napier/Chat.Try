using BlazorChat;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Fennorad.Areas.Identity;
using Fennorad.Db.Accessors;
using Fennorad.Db.Context;
using Fennorad.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Fennorad.AnthropicClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>(opt =>
{
    return new Configuration
    {
        PythonPath = builder.Configuration.GetValue<string>("PythonPath"),
        YoutubeDLPath = builder.Configuration.GetValue<string>("YoutubeDLPath"),
        MapAccessToken = builder.Configuration.GetValue<string>("MapAccessToken"),
        FfmpegPath = builder.Configuration.GetValue<string>("FfmpegPath"),
        AnthropicBaseAddress = builder.Configuration.GetValue<string>("AnthropicBaseAddress"),
        AnthropicApiKey = builder.Configuration.GetValue<string>("AnthropicApiKey"),
        AnthropicVersion = builder.Configuration.GetValue<string>("AnthropicVersion")
    };
});

// Add services to the container.
builder.Services.AddScoped<IUserDbAccessor, UserDbAccessor>();
builder.Services.AddScoped<IChatDbAccessor, ChatDbAccessor>();
var connectionString = builder.Configuration.GetConnectionString("Chat");
builder.Services.AddDbContext<Fennorad.Db.Context.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ChatContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<Fennorad.Db.Context.ApplicationDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
    
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true; 
    options.User.RequireUniqueEmail = true;
});
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<IHostEnvironmentAuthenticationStateProvider>(sp => {
    // this is safe because 
    //     the `RevalidatingIdentityAuthenticationStateProvider` extends the `ServerAuthenticationStateProvider`
    var provider = (ServerAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>();
    return provider;
});
builder.Services.RegisterAnthropicClient(builder.Configuration.GetValue<string>("AnthropicApiKey"));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
});
builder.Services.AddBlazorDownloadFile();
builder.Services.AddSingleton(new YouTubeService(new BaseClientService.Initializer()
{
    ApiKey = builder.Configuration.GetValue<string>("YoutubeApiKey"),
    ApplicationName = "youtube-app-141704",

}));
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapHub<ChatHub>("/chathub");
app.MapFallbackToPage("/_Host");
app.Run();
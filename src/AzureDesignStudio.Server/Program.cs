using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using AzureDesignStudio.Server.Models;
using AzureDesignStudio.Server.Services;
using AzureDesignStudio.Server.Utils;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));
builder.Services.Configure<JwtBearerOptions>(
    JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters.NameClaimType = "name";
    });

#if DEBUG
    builder.Services.AddDbContext<DesignDbContext>(options => options.UseInMemoryDatabase("adsdb-inmem"));
#else
    builder.Services.AddDbContext<DesignDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDbConnection")));
#endif

builder.Services.AddSingleton<ITelemetryInitializer, AdsTelemetryInitializer>();
builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddRazorPages();
builder.Services.AddGrpc();

#if DEBUG
    builder.Services.AddGrpcReflection();
#endif
// For running behind an ingress
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseGrpcWeb();
app.MapGrpcService<DesignService>().EnableGrpcWeb();

#if DEBUG
    if (app.Environment.IsDevelopment())
    {
        app.MapGrpcReflectionService();
    }
#endif

app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.Run();

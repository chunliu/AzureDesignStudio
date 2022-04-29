using AzureDesignStudio;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Models;
using AzureDesignStudio.Services;
using AzureDesignStudio.SharedModels.Protos;
using BlazorApplicationInsights;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AzureDesignStudio.ResourceAccess", 
    client => client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ResourceRoot")));
// AAD B2C Authentication
builder.Services.AddHttpClient("AzureDesignStudio.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AzureDesignStudio.ServerAPI"));
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.Cache.CacheLocation = "localStorage";
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://account.azuredesign.app/8af9ef93-105f-49a6-bea6-5fae083ce3c5/Server.Access");
});

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
// App insights
builder.Services.AddBlazorApplicationInsights();
// Grpc
builder.Services.AddScoped<DesignGrpcService>();
builder.Services.AddGrpcClient<Design.DesignClient>("DesignClientWithAuth", o =>
{
    o.Address = new Uri(builder.HostEnvironment.BaseAddress);
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    var baseAddressMessageHandler = builder.Services.BuildServiceProvider().GetRequiredService<BaseAddressAuthorizationMessageHandler>();
    baseAddressMessageHandler.InnerHandler = new HttpClientHandler();
    return new GrpcWebHandler(GrpcWebMode.GrpcWeb, baseAddressMessageHandler);
});

builder.Services.AddAntDesign();
builder.Services.AddSingleton<AdsContext>();
builder.Services.AddAutoMapper(typeof(AzureNodeProfile));

var host = builder.Build();

var adsContext = host.Services.GetRequiredService<AdsContext>();
await adsContext.InitializeAsync();

await host.RunAsync();

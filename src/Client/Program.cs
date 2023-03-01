using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CanidateApp.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




builder.Services.AddMudServices();

builder.Services.AddHttpClient("CanidateApp.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CanidateApp.ServerAPI"));

builder.Services.AddMsalAuthentication<RemoteAuthenticationState, CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://b2crmsconnect.onmicrosoft.com/e098b33a-11a3-47f2-8771-611a96d9c25b/API_Access");

}).AddAccountClaimsPrincipalFactory<RemoteAuthenticationState,
    CustomUserAccount, CustomAccountFactory>(); 






builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient("WebApi",
        client => client.BaseAddress = new Uri("https://demographqlserver.azurewebsites.net/"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();



builder.Services.AddHttpClient(DemoClient.ClientName,
        client => client.BaseAddress = new Uri("https://demographqlserver.azurewebsites.net/graphql"))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();



builder.Services.AddDemoClient();





    await builder.Build().RunAsync();

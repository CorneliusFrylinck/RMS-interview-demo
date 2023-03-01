namespace CanidateApp.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: new[] { "https://localhost:7279" , "https://demographqlserver.azurewebsites.net", "https://demographqlserver.azurewebsites.net/graphql" },
            scopes: new[] { "https://b2crmsconnect.onmicrosoft.com/183119a8-3f88-48db-bfbe-044704626cde/graph_access" });
    }
}
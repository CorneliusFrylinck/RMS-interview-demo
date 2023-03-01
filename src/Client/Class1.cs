using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CanidateApp.Client;

public class CustomUserAccount : RemoteUserAccount
{
    [JsonPropertyName("amr")]
    public string[] AuthenticationMethod { get; set; }
}

public class CustomAccountFactory
    : AccountClaimsPrincipalFactory<CustomUserAccount>
{
    public CustomAccountFactory(NavigationManager navigation,
        IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
        CustomUserAccount account, RemoteAuthenticationUserOptions options)
    {
        var initialUser = await base.CreateUserAsync(account, options);

        if (initialUser.Identity.IsAuthenticated)
        {
            var dds = initialUser.Claims.ToList().Select(c => c.Type).ToList();


            ((ClaimsIdentity)initialUser.Identity)
                .AddClaim(new Claim(ClaimTypes.Role, "User"));


            var dd = initialUser.Claims.Where(c => c.Type.Contains("extension_UserRoles")).Select(c => c.Value).ToList();

            foreach (var claim in dd)
            {
                var enumerable = claim.Split(",");
                foreach (var s in enumerable)
                {
                    if (string.IsNullOrEmpty(s)) continue;

                    ((ClaimsIdentity)initialUser.Identity)
                        .AddClaim(new Claim(ClaimTypes.Role, s));
                }
            }


        }


        var ss = 0;



        //     try
        //     {





        //if (initialUser.Identity.IsAuthenticated)
        //     {
        //         foreach (var value in account.AuthenticationMethod)
        //         {
        //             ((ClaimsIdentity)initialUser.Identity)
        //                 .AddClaim(new Claim("amr", value));
        //         }
        //     }

        //     }
        //     catch (Exception e)
        //     {

        //     }





        return initialUser;
    }
}


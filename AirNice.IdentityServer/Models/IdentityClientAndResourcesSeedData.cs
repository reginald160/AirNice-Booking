using AirNice.Models.Models;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNice.IdentityServer.Models
{
    public class IdentityClientAndResourcesSeedData
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myApi", "API BACKEND")
                {
                    Scopes = new List<string>()
                    {
                        "myApi"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope(name: "myApi.access", displayName: "Acessar API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetMainClients(IConfiguration configuration)
        {
            var clientList = new List<Client>();

            /* Config MVC Client */
            var mvcClientConfig = new Passenger();
            configuration.Bind("IdentityServerClients:MvcClient", mvcClientConfig);

            clientList.Add(
                // OpenID Connect hybrid flow client (MVC)
                new Client
                {
                    ClientId = mvcClientConfig.Id.ToString(),
                    ClientName = mvcClientConfig.Name,
                    AllowedGrantTypes = GrantTypes.Code,

                    ClientSecrets = {new Secret(Config.Secret)},

                    RedirectUris = {$"{Config.Url}/signin-oidc"},
                    PostLogoutRedirectUris =
                        {$"{Config.Url}/signout-callback-oidc"},
                    RequireConsent = false,
                    RequirePkce = false,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "myApi.access",
                        "offline_access"
                    },
                    AllowOfflineAccess = true
                }
            );

// ... insert other necessary clients here

            return clientList;
        }
    }

}

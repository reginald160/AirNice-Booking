using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AirNice.IdentityServer.Models
{
    public static class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            using var dbSession = serviceProvider.GetRequiredService<IAsyncDocumentSession>();

            // 1. Identity Resources
            var identityResourcesToSeed =
                IdentityClientAndResourcesSeedData.GetIdentityResources();

            foreach (var item in identityResourcesToSeed)
            {
                var preExistingItem = await dbSession.Query<IdentityResource>()
                    .Where(wh => wh.Name == item.Name)
                    .FirstOrDefaultAsync();

                if (preExistingItem != null)
                {
                    // deletes
                    dbSession.Delete(preExistingItem);
                }

                await dbSession.StoreAsync(item);
            }

            // 2. Api Resources
            var apiResourcesToSeed =
                IdentityClientAndResourcesSeedData.GetApiResources();

            foreach (var item in apiResourcesToSeed)
            {
                var preExistingItem = await dbSession.Query<ApiResource>()
                    .Where(wh => wh.Name == item.Name)
                    .FirstOrDefaultAsync();

                if (preExistingItem != null)
                {
                    // deletes
                    dbSession.Delete(preExistingItem);
                }

                await dbSession.StoreAsync(item);
            }

            // 3. Api Scopes
            var apiScopesToSeed =
                IdentityClientAndResourcesSeedData.GetApiScopes();

            foreach (var item in apiScopesToSeed)
            {
                var preExistingItem = await dbSession.Query<ApiScope>()
                    .Where(wh => wh.Name == item.Name)
                    .FirstOrDefaultAsync();

                if (preExistingItem != null)
                {
                    // deletes
                    dbSession.Delete(preExistingItem);
                }

                await dbSession.StoreAsync(item);
            }

            // 4. Identity Clients
            var mainClientsToSeed =
                IdentityClientAndResourcesSeedData.GetMainClients(configuration);

            foreach (var item in mainClientsToSeed)
            {
                var preExistingItem = await dbSession.Query<Client>()
                    .Where(wh => wh.ClientId == item.ClientId)
                    .FirstOrDefaultAsync();

                if (preExistingItem != null)
                {
                    // deletes
                    dbSession.Delete(preExistingItem);
                }

                await dbSession.StoreAsync(item);
            }

            await dbSession.SaveChangesAsync();
        }
    }

}

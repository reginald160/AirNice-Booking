using IdentityServer4.Models;
using IdentityServer4.Stores;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AirNice.IdentityServer.Models
{
    public class ResourceStore : IResourceStore
    {
        private readonly IAsyncDocumentSession _dbSession;

        public ResourceStore(
            IAsyncDocumentSession dbSession
            )
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(
            IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var _identityResources =
                await _dbSession.Query<IdentityResource>().ToListAsync();

            var identity = from i in _identityResources
                           where scopeNames.Contains(i.Name)
                           select i;

            return identity;
        }

        public async Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var _apiScopes =
                await _dbSession.Query<ApiScope>().ToListAsync();

            var query =
                from x in _apiScopes
                where scopeNames.Contains(x.Name)
                select x;

            return query;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var allData =
                await _dbSession.Query<ApiResource>().ToListAsync();

            var query = from a in allData
                        where a.Scopes.Any(x => scopeNames.Contains(x))
                        select a;

            return query;
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(
            IEnumerable<string> apiResourceNames
            )
        {
            if (apiResourceNames == null) throw new ArgumentNullException(nameof(apiResourceNames));

            var allData =
                await _dbSession.Query<ApiResource>().ToListAsync();

            var query = from a in allData
                        where apiResourceNames.Contains(a.Name)
                        select a;

            return query;
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var allApiResources =
                await _dbSession.Query<ApiResource>().ToListAsync();
            var allApiScopes =
                await _dbSession.Query<ApiScope>().ToListAsync();
            var allIdentityResources =
                await _dbSession.Query<IdentityResource>().ToListAsync();

            return new Resources(allIdentityResources, allApiResources, allApiScopes);
        }
    }

}

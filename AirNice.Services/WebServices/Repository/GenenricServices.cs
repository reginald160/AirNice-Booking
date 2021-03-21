
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.WebServices.Repository
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {
        protected readonly IHttpClientFactory _clientFactory;
        public bool IsCoreDeletetable { get; set; }
        internal DbSet<T> dbSet;

        public GenericServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
           
        }

        public async Task<T> GetByIdAsync(string url, Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonDeseriazed = JsonConvert.DeserializeObject<T>(jsonString);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? jsonDeseriazed : null;
        }

        public async Task <IEnumerable<T>> ReserveCollection(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonDeseriazed = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? jsonDeseriazed: null;

        }

        public IEnumerable<T> Trashcollection(string url)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAndRetrieveAync(string url, T TEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAndRetrieveAsync(string url, Guid id)
        {
            var entity = await GetByIdAsync(url,id);
            var resquest = new HttpRequestMessage(HttpMethod.Patch, url);
            if (entity == null)
                return false;
            resquest.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(resquest);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false;
        }

        public async Task<bool> AddAsync(string url, T entity)
        {
          
            var resquest = new HttpRequestMessage(HttpMethod.Post, url);
            if(entity == null)
                return false;
            resquest.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
    
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(resquest);
            return response.StatusCode == System.Net.HttpStatusCode.Created ? true : false;
                    
        }

        public async Task<bool> UpdateAsync(string url, T entity)
        {
            var resquest = new HttpRequestMessage(HttpMethod.Patch, url);
            if (entity == null)
                return false;
            resquest.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(resquest);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false;

        }

        public async Task <bool> Remove(string url, Guid id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url + id);
            HttpClient client =  _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? true : false;
        }

        public Task Remove(string url, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsExisting(string url, Guid id)
        {
            throw new NotImplementedException();
        }

      
    }


}   

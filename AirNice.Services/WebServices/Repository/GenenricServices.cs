using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Utility.CoreHelpers;
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

        public Task<T> GetByIdAsync(string url, Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReserveCollection(string url)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Trashcollection(string url)
        {
            throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, string url = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAndRetrieveAync(string url, T TEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAndRetrieveAsync(string url, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddAsync(string url, T entity)
        {
            var resquest = new HttpRequestMessage(HttpMethod.Post, url);
            if(entity != null)
                resquest.Content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            return false;

            HttpClient client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(resquest);
            return response.StatusCode == System.Net.HttpStatusCode.Created ? true : false;
                    
            
            



        }

        public Task<bool> UpdateAsync(string url, T entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string url, Guid id)
        {
            throw new NotImplementedException();
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

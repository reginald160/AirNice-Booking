using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.WebServices.Repository
{
    public interface IGenericServices<T> where T : class
    {
        Task<T> GetByIdAsync(string url,Guid id);

        IEnumerable<T> ReserveCollection(string url);
        IEnumerable<T> Trashcollection(string url);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, string url);
        Task<bool> DeleteAndRetrieveAync(string url,T TEntity);
        Task <bool>DeleteAndRetrieveAsync(string url, Guid id);
        Task<bool> AddAsync(string url,T entity);
        Task<bool> UpdateAsync(string url,T entity);
        Task Remove(string url,Guid id);
        Task Remove(string url,T entity);
        Task<bool> SaveAsync();
        bool IsExisting(string url,Guid id);
    }
}

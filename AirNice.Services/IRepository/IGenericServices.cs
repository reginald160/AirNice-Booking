﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.IRepository
{
    public interface IGenericServices<T> where T : class
    {
        T GetById(Guid id);

        IEnumerable<T> ReserveCollection();
        IEnumerable<T> Trashcollection();

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<bool> DeleteAndRetrieveAync(T TEntity);
        Task <bool>DeleteAndRetrieveAsync(Guid id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task Remove(Guid id);
        Task Remove(T entity);
        Task<bool> SaveAsync();
        bool IsExisting(Guid id);
    }
}

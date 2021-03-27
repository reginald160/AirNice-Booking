using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Utility.CoreHelpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.Repository
{
   public class GenenricServices
    {

        public class GenericServices<T> : IGenericServices<T> where T : class
        {
            protected readonly ApplicationDbContext _Context;
            public bool IsCoreDeletetable { get; set; }
            internal DbSet<T> dbSet;

            public GenericServices(ApplicationDbContext context)
            {
                _Context = context;
                this.dbSet = context.Set<T>();
                //var IsCoreDeletetable = typeof(T).GetInterfaces().Contains(typeof(ICoreDeletable));

            }

            //private readonly IRoles _roles;
            //private readonly SuperAdminDefaultOptions _superAdminDefaultOptions;

            public IEnumerable<T> AddRange(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                dbSet.AddRange(entities);
                return entities;
            }

            public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");
                await dbSet.AddRangeAsync(entities);
                return entities;
            }

            public async Task<T> AddAsync(T entity)
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                await  dbSet.AddAsync(entity);
            var  success = await   _Context.SaveChangesAsync() > 0;
                if(success.Equals(true))
                    return entity;
                return null;

            }
            public bool GetDeletedValue()
            {
                var trueValue = (bool)typeof(T).GetProperty(Universe.DeleteClature).Equals(Universe.Deleted);

                return trueValue;
            }
            public T GetById(Guid id)
            {
                return dbSet.Find(id);
            }
            public bool IsExisting(string name, Guid id, string propertyName)
            {
              
                var entity = GetById((Guid)id);
                var getpropName = entity.GetType().GetProperty(propertyName).GetValue(entity);
                var value = entity.GetType().GetProperty(propertyName);
                bool status = dbSet.Any(a => a.GetType().GetProperty(propertyName).GetValue(entity).ToString() == name);

                return status ? true : false;
            }

            public IEnumerable<T> GetAll(object obj)
            {

                List<T> Entities = new List<T>();
                IQueryable<T> query = dbSet;

                var queryies = query.ToList();
                foreach (var entity in queryies)
                {
                    var deleteValue = entity.GetType().GetProperty(Universe.DeleteClature).GetValue(entity);
                    if (deleteValue.Equals(obj))
                        Entities.Add(entity);
                }
                return Entities;
            }

            public IEnumerable<T> ReserveCollection()
            {
                var entities = GetAll(!Universe.Deleted);

                return entities;
            }

            public IEnumerable<T> Trashcollection()
            {
                var entities = GetAll(Universe.Deleted);

                return entities;
            }

            public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
            {
                IQueryable<T> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                //include properties will be comma seperated
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return query.FirstOrDefault();

            }
            public async Task<bool> DeleteAndRetrieveAync(T TEntity)
            {
                var id = TEntity.GetType().GetProperty("Id").GetValue(TEntity);
                var entity = GetById((Guid)id);
                var delete = entity.GetType().GetProperty(Universe.DeleteClature).GetValue(entity);
                var deleteVm = TEntity.GetType().GetProperty(Universe.DeleteClature);

                if (delete.Equals(Universe.NotTrue))
                {
                    deleteVm.SetValue(TEntity, Universe.Deleted);
                    _Context.Entry(entity).CurrentValues.SetValues(TEntity);
                    var sucess = await _Context.SaveChangesAsync() > 0;
                    return sucess ? true : false;

                }
                else
                {
                    deleteVm.SetValue(TEntity, !Universe.Deleted);
                    _Context.Entry(entity).CurrentValues.SetValues(TEntity);
                    var sucess = await _Context.SaveChangesAsync() > 0;
                    return sucess ? true : false;

                }
            }

            public async Task<bool> DeleteAndRetrieveAsync(Guid id)
            {

                var entity = GetById((Guid)id);
                var delete = entity.GetType().GetProperty(Universe.DeleteClature).GetValue(entity);
                var deleteVm = entity.GetType().GetProperty(Universe.DeleteClature);
                if (delete.Equals(Universe.NotTrue))
                {
                    deleteVm.SetValue(entity, Universe.Deleted);
                    _Context.Entry(entity).CurrentValues.SetValues(entity);
                    var save =  await SaveAsync();
                    return save;

                }
                else
                {
                    deleteVm.SetValue(entity, !Universe.Deleted);
                    _Context.Entry(entity).CurrentValues.SetValues(entity);
                    var save = await SaveAsync();
                    return save;
                }
            }

            public async Task<bool> UpdateAsync(T entity)
            {
           
                _Context.Update(entity);
                
                var save = await SaveAsync();
                return save;

            }


            public async Task Remove(Guid id)
            {
                T entityToRemove = await dbSet.FindAsync(id);
                await Remove(entityToRemove);
            }

            public async Task Remove(T entity)
            {
                dbSet.Remove(entity);

            }

            public async Task<bool> SaveAsync()
            {
                var sucess = await _Context.SaveChangesAsync() > 0;
                return sucess ? true : false;

            }

            public bool IsExisting(Guid id)
            {
                var status = GetById(id);
                return status != null ? true : false;
            }
        }

    }
}

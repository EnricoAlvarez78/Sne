using Microsoft.EntityFrameworkCore;
using Sidetech.Sne.Data.Context;
using Sidetech.Sne.Data.Helpers;
using Sidetech.Sne.Domain.Helpers.FilterHelpers;
using Sidetech.Sne.Domain.Helpers.ResultHelpers;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sidetech.Sne.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected EfCore2Context Db = new EfCore2Context();

        #region QueryOperations

        public virtual async Task<GetOneResult<TEntity>> GetById(int id)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var entitie = await Db.Set<TEntity>().FindAsync(id);

                result.Entity = entitie;
                result.Success = true;
                result.Message = "OK";
                result.StatusCode = 200;
                result.Exception = null;
            }
            catch (Exception ex)
            {
                result.Entity = null;
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }

            return result;
        }

        public virtual async Task<GetCountResult<TEntity>> Count(GetManyFilter<TEntity> filter)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>();

            query = GenericFilterHelper<TEntity>.GenericFilter(query, filter?.Filters);

            return await Counter(query);
        }

        protected async Task<GetCountResult<TEntity>> Counter(IQueryable<TEntity> query)
        {
            var result = new GetCountResult<TEntity>();
            try
            {
                var amount = await query.AsNoTracking().CountAsync();

                result.Amount = amount;
                result.Success = true;
                result.Message = "OK";
                result.StatusCode = 200;
                result.Exception = null;
            }
            catch (Exception ex)
            {
                result.Amount = null;
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }
            return result;
        }

        public virtual async Task<GetManyResult<TEntity>> GetMany(SearchFilter<TEntity> filter)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>();

            query = GenericFilterHelper<TEntity>.GenericFilter(query, filter?.Filters);

            return await Search(query, filter);
        }

        protected async Task<GetManyResult<TEntity>> Search(IQueryable<TEntity> query, SearchFilter<TEntity> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var totalAmount = await query.AsNoTracking().CountAsync();

                if (filter != null)
                {
                    if (filter.Sort != null && filter.Sort.Count > 0)
                    {
                        query = query.Sort(string.Concat(filter.Sort.Values.FirstOrDefault(), " ", filter.Sort.Keys.FirstOrDefault()));
                    }

                    if (filter.PageIndex != null && filter.PageIndex > 0 && filter.PageSize != null && filter.PageSize > 0)
                    {
                        query = query.Skip(filter.PageSize.GetValueOrDefault() * (filter.PageIndex.GetValueOrDefault() - 1)).Take(filter.PageSize.GetValueOrDefault());
                    }
                }

                var entities = await query.AsNoTracking().ToListAsync();

                result.Entities = entities;
                result.TotalAmount = totalAmount;
                result.Success = true;
                result.Message = "OK";
                result.StatusCode = 200;
                result.Exception = null;
            }
            catch (Exception ex)
            {
                result.Entities = null;
                result.TotalAmount = 0;
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }
            return result;
        }

        #endregion

        #region NoQueryOperations

        public virtual async Task<GetOneResult<TEntity>> Add(TEntity obj)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                Db.Set<TEntity>().Add(obj);
                int entriesWritten = await Db.SaveChangesAsync();

                if (entriesWritten >= 1)
                {
                    result.Entity = obj;
                    result.Success = true;
                    result.Message = "Created";
                    result.StatusCode = 201;
                    result.Exception = null;
                }
                else
                {
                    result.Entity = null;
                    result.Success = false;
                    result.Message = "Bad Request";
                    result.StatusCode = 400;
                    result.Exception = null;
                }
            }
            catch (Exception ex)
            {
                result.Entity = null;
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }

            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity obj)
        {
            var result = new OperationResult();

            try
            {
                Db.Entry(obj).State = EntityState.Modified;

                int entriesWritten = await Db.SaveChangesAsync();

                if (entriesWritten < 1)
                {
                    result.Success = false;
                    result.Message = "Bad Request";
                    result.StatusCode = 400;
                    result.Exception = null;
                }
                else
                {
                    result.Success = true;
                    result.Message = "No Content";
                    result.StatusCode = 204;
                    result.Exception = null;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }

            return result;
        }

        public virtual async Task<OperationResult> Remove(TEntity obj)
        {
            var result = new OperationResult();

            try
            {
                Db.Set<TEntity>().Remove(obj);

                int entriesWritten = await Db.SaveChangesAsync();

                if (entriesWritten < 1)
                {
                    result.Success = false;
                    result.Message = "Bad Request";
                    result.StatusCode = 400;
                    result.Exception = null;
                }
                else
                {
                    result.Success = true;
                    result.Message = "No Content";
                    result.StatusCode = 204;
                    result.Exception = null;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }

            return result;
        }
       
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

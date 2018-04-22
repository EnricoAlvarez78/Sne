using Sidetech.Sne.Domain.Helpers.FilterHelpers;
using Sidetech.Sne.Domain.Helpers.ResultHelpers;
using Sidetech.Sne.Domain.Interfaces.Repositories;
using Sidetech.Sne.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Sidetech.Sne.DomainService.Services
{
    public abstract class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<GetOneResult<TEntity>> GetById(int id)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var response = await _repository.GetById(id);

                if (response.Success)
                {
                    if (response.Entity == null)
                    {
                        result.Message = "Not Found";
                        result.StatusCode = 404;
                    }
                    else
                    {
                        result.Message = "OK";
                        result.StatusCode = 200;
                    }

                    result.Entity = response.Entity;
                    result.StatusCode = response.StatusCode == 400 ? 400 : response.StatusCode;
                    result.Exception = response.Exception ?? null;
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

        public virtual async Task<GetCountResult<TEntity>> Count(GetManyFilter<TEntity> filter)
        {
            var result = new GetCountResult<TEntity>();

            try
            {
                var response = await _repository.Count(filter);

                if (response.Success)
                {
                    result.Amount = response.Amount;
                    result.Success = true;
                    result.Message = "OK";
                    result.StatusCode = 200;
                    result.Exception = null;
                }
                else
                {
                    result.Amount = null;
                    result.Success = false;
                    result.Message = response.Message == "Bad Request" ? "Bad Request" : response.Message;
                    result.StatusCode = response.StatusCode == 400 ? 400 : response.StatusCode;
                    result.Exception = response.Exception ?? null;
                }
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
            var result = new GetManyResult<TEntity>();

            try
            {
                var response = await _repository.GetMany(filter);

                if (response.Success)
                {
                    result.Entities = response.Entities;
                    result.TotalAmount = response.TotalAmount;
                    result.Message = "OK";
                    result.Success = true;
                    result.StatusCode = 200;
                    result.Exception = null;
                }
                else
                {
                    result.Entities = null;
                    result.TotalAmount = 0;
                    result.Success = false;
                    result.Message = response.Message == "Bad Request" ? "Bad Request" : response.Message;
                    result.StatusCode = response.StatusCode == 400 ? 400 : response.StatusCode;
                    result.Exception = response.Exception ?? null;
                }
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

        public virtual async Task<GetOneResult<TEntity>> Add(TEntity obj)
        {
            var result = new GetOneResult<TEntity>();

            try
            {
                var response = await _repository.Add(obj);

                if (response.Success)
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
                    result.Message = response.Message == "Bad Request" ? "Bad Request" : response.Message;
                    result.StatusCode = response.StatusCode == 400 ? 400 : response.StatusCode;
                    result.Exception = response.Exception ?? null;
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
                var response = await _repository.Update(obj);

                if (response.Success)
                {
                    result.Success = true;
                    result.Message = "No Content";
                    result.StatusCode = 204;
                    result.Exception = null;
                }
                else
                {
                    result.Success = false;
                    result.Message = response.Message == "Bad Request" ? "Bad Request" : response.Message;
                    result.StatusCode = response.StatusCode == 400 ? 400 : response.StatusCode;
                    result.Exception = response.Exception ?? null;
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

        public virtual async Task<OperationResult> Remove(int id)
        {
            var result = new OperationResult();

            try
            {
                var entity = await _repository.GetById(id);

                if (!entity.Success || entity.Entity == null)
                {
                    result.Success = false;
                    result.Message = "Not Found";
                    result.StatusCode = 404;
                    result.Exception = null;
                }
                else
                {
                    var wasDeleted = await _repository.Remove(entity.Entity);

                    if (wasDeleted.Success)
                    {
                        result.Success = true;
                        result.Message = "No Content";
                        result.StatusCode = 204;
                        result.Exception = null;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = wasDeleted.Message == "Bad Request" ? "Bad Request" : wasDeleted.Message;
                        result.StatusCode = wasDeleted.StatusCode == 400 ? 400 : wasDeleted.StatusCode;
                        result.Exception = wasDeleted.Exception ?? null;
                    }
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
    }
}

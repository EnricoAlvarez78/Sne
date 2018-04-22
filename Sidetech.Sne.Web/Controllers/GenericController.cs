using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sidetech.Sne.Domain.Helpers.ResultHelpers;
using Sidetech.Sne.Domain.Interfaces.Services;
using Sidetech.Sne.Web.CustomAttributes;
using Sidetech.Sne.Web.Helpers;
using Sidetech.Sne.Web.Helpers.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sidetech.Sne.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ValidateModel]
    public abstract class GenericController<TEntity, TModel> : Controller 
        where TEntity : class
        where TModel : class
    {
        private object _service;

        public GenericController(object service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public virtual async Task<JsonResult> GetAll()
        {
            var result = new GetManyResult<TModel>();
            try
            {
                var response = await  ((IGenericService<TEntity>)_service).GetMany(null);

                if (response.Success)
                {
                    result.Success = response.Success;
                    result.Entities = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(response.Entities);
                    result.TotalAmount = response.TotalAmount;
                    result.Message = response.Message;
                    result.StatusCode = response.StatusCode;
                    result.Exception = null;
                }
                else
                {
                    result.Success = false;
                    result.Entities = response.Entities == null ? null : Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(response.Entities);
                    result.TotalAmount = response.TotalAmount <= 0 ? 0 : response.TotalAmount;
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
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

            return Json(result);
        }

        [HttpGet("GetById")]
        public async Task<JsonResult> GetById(int id)
        {
            var result = new GetOneResult<TModel>();
            try
            {
                var response = await ((IGenericService<TEntity>)_service).GetById(id);

                if (response.Success)
                {
                    result.Success = response.Success;
                    result.Entity = Mapper.Map<TEntity, TModel>(response.Entity);
                    result.Message = response.Message;
                    result.StatusCode = response.StatusCode;
                    result.Exception = null;
                }
                else
                {
                    result.Success = false;
                    result.Entity = response.Entity == null ? null : Mapper.Map<TEntity, TModel>(response.Entity);
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
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

            return Json(result);
        }

        [HttpPost("Search")]
        public async Task<JsonResult> Search([FromBody]SearchModel filter)
        {
            var result = new GetManyResult<TModel>();

            try
            {
                var request = ConvertSearchModelToSearchFilter<TEntity>.Convert(filter);

                var response = await ((IGenericService<TEntity>)_service).GetMany(request);

                if (response.Success)
                {
                    result.Success = response.Success;
                    result.Entities = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(response.Entities);
                    result.TotalAmount = response.TotalAmount;
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
                    result.Exception = response.Exception ?? null;
                }
                else
                {
                    result.Success = false;
                    result.Entities = response.Entities == null ? null : Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(response.Entities);
                    result.TotalAmount = response.TotalAmount <= 0 ? 0 : response.TotalAmount;
                    result.Message = response.Message;
                    result.StatusCode = response.StatusCode;
                    result.Exception = response.Exception;
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

            return Json(result);
        }

        [HttpPost("Count")]
        public async Task<JsonResult> Count([FromBody]SearchModel filter)
        {
            var result = new GetCountResult<TModel>();
            try
            {
                var request = ConvertSearchModelToSearchFilter<TEntity>.Convert(filter);

                var response = await ((IGenericService<TEntity>)_service).Count(request);

                if (response.Success)
                {
                    result.Success = response.Success;

                    result.Amount = response.Amount;
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
                    result.Exception = response.Exception ?? null;
                }
                else
                {
                    result.Success = false;

                    result.Amount = response.Amount <= 0 ? 0 : response.Amount;
                    result.Message = response.Message;
                    result.StatusCode = response.StatusCode;
                    result.Exception = response.Exception;
                }
            }
            catch (Exception ex)
            {
                result.Amount = 0;
                result.Success = false;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }
            return Json(result);
        }

        [HttpPost("Add")]
        public async Task<JsonResult> Post([FromBody]TModel model)
        {
            var result = new GetOneResult<TModel>();
            try
            {
                var domain = Mapper.Map<TModel, TEntity>(model);

                var response = await ((IGenericService<TEntity>)_service).Add(domain);

                if (response.Success)
                {
                    result.Success = true;
                    result.Entity = Mapper.Map<TEntity, TModel>(response.Entity);
                    result.Message = "Created";
                    result.StatusCode = 201;
                    result.Exception = null;
                }
                else
                {
                    result.Success = false;
                    result.Entity = response.Entity == null ? null : Mapper.Map<TEntity, TModel>(response.Entity);
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
                    result.Exception = response.Exception ?? null;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Entity = null;
                result.Message = ex.Message;
                result.StatusCode = 500;
                result.Exception = ex;
            }
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task<JsonResult> Put([FromBody]TModel model)
        {
            var result = new OperationResult();
            try
            {
                var domain = Mapper.Map<TModel, TEntity>(model);

                var response = await ((IGenericService<TEntity>)_service).Update(domain);

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
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
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
            return Json(result);
        }

        [HttpDelete("Delete")]
        public async Task<JsonResult> Delete(int id)
        {
            var result = new OperationResult();

            try
            {
                var response = await ((IGenericService<TEntity>)_service).Remove(id);

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
                    result.Message = response.Message ?? null;
                    result.StatusCode = response.StatusCode;
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

            return Json(result);
        }
    }
}
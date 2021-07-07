using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LowCodeAPI.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Net;
using System.Linq.Expressions;
using System.Linq;

namespace LowCodeAPI.Client.Services
{
    /// <summary>
    /// Reusable API Repository base class that provides access to CRUD APIs
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class APIRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        string controllerName;
        string primaryKeyName;
        HttpClient http;

        public APIRepository(HttpClient _http, string _controllerName, string _primaryKeyName)
        {
            http = _http;
            controllerName = _controllerName;
            primaryKeyName = _primaryKeyName;
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var result = await http.GetAsync(controllerName);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TEntity>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return new List<TEntity>();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByValue(string PropertyName, string Value)
        {
            try
            {
                
                var url = $"{controllerName}/{WebUtility.HtmlEncode(PropertyName)}/{WebUtility.HtmlEncode(Value)}/GetByValue";
                var result = await http.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public async Task<IEnumerable<TEntity>> SearchByValue(string PropertyName, string Value)
        {
            try
            {
                var url = $"{controllerName}/{WebUtility.HtmlEncode(PropertyName)}/{WebUtility.HtmlEncode(Value)}/SearchByValue";
                var result = await http.GetAsync(url);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIListOfEntityResponse<TEntity>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            try
            {
                var result = await http.PostAsJsonAsync(controllerName, entity);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TEntity> Update(TEntity entityToUpdate)
        {
            try
            {
                var result = await http.PutAsJsonAsync(controllerName, entityToUpdate);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<APIEntityResponse<TEntity>>(responseBody);
                if (response.Success)
                    return response.Data;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Delete(TEntity entityToDelete)
        {
            try
            {
                var value = entityToDelete.GetType()
                    .GetProperty(primaryKeyName)
                    .GetValue(entityToDelete, null)
                    .ToString();

                return await DeleteByValue(primaryKeyName, value);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteByValue(string PropertyName, string Value)
        {
            try
            {
                var url = $"{controllerName}/{WebUtility.HtmlEncode(PropertyName)}/{WebUtility.HtmlEncode(Value)}/DeleteByValue";
                var result = await http.DeleteAsync(url);
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

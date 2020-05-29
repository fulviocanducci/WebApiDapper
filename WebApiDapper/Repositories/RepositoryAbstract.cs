using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApiDapper.Repositories
{
    public abstract class RepositoryAbstract<T> : IRepository<T> where T : class, new()
    {
        public IDbConnection Connection { get; }

        public RepositoryAbstract(IDbConnection connection)
        {
            Connection = connection;
        }

        #region Methods

        public T Insert(T model) 
        {
            Connection.Insert<T>(model);
            return model;
        }

        public bool Remove<TKey>(TKey value)
        {
            T model = Get<TKey>(value);
            return model != null && Connection.Delete(model);
        }

        public bool Update(T model)
        {
            return Connection.Update<T>(model);
        }

        public IEnumerable<T> Get()
        {
            return Connection.GetAll<T>();
        }

        public T Get<TKey>(TKey value)
        {
            return Connection.Get<T>(value);
        }

        #endregion

        #region MethodsAsync

        public async Task<T> InsertAsync(T model)
        {
            await Connection.InsertAsync<T>(model);
            return model;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            return await Connection.UpdateAsync<T>(model);
        }

        public async Task<bool> RemoveAsync<TKey>(TKey value)
        {
            T model = await GetAsync(value);
            return model != null && await Connection.DeleteAsync(model);
        }

        public async Task<T> GetAsync<TKey>(TKey value)
        {
            return await Connection.GetAsync<T>(value);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Connection.GetAllAsync<T>();
        }

        #endregion
    }
}

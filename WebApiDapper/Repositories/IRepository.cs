using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace WebApiDapper.Repositories
{
    public interface IRepository<T> where T: class, new()
    {
        IDbConnection Connection { get; }
        T Insert(T model);
        bool Update(T model);
        bool Remove<TKey>(TKey value);
        T Get<TKey>(TKey value);
        IEnumerable<T> Get();

        Task<T> InsertAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> RemoveAsync<TKey>(TKey value);
        Task<T> GetAsync<TKey>(TKey value);
        Task<IEnumerable<T>> GetAsync();
    }
}

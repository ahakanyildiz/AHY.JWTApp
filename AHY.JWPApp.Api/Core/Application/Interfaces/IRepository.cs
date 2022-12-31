using AHY.JWPApp.Api.Core.Domain;
using System.Linq.Expressions;

namespace AHY.JWPApp.Api.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T unChanged, T updated);
        Task RemoveAsync(T entity);
    }
}

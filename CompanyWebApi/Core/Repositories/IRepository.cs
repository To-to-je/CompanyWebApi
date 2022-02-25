using System.Linq.Expressions;

namespace CompanyWebApi.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        Task<TEntity?> Get(int id);
        Task<IEnumerable<TEntity>>  GetAll();
        Task<IEnumerable<TEntity>>  Find(Expression<Func<TEntity, bool>> predicate);

        


        Task Add(TEntity entity);
        Task<bool> AddRange(IEnumerable<TEntity> entities);
        Task<bool> Remove(int id);
        Task<bool> Exists(int id);



    }
}

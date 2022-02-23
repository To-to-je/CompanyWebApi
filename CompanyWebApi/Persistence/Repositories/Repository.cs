using System.Linq.Expressions;
using CompanyWebApi.Core.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }




        public async Task<TEntity?> Get(int id)
        {
            return await DbSet.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync() ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            if (await DbSet.Where(predicate).AnyAsync())
            {
                return await DbSet.Where(predicate).Select(e=>e).ToListAsync();
            }
            else
            {
                throw new NullReferenceException("No requested entities in database");
            }
        }

        public async Task Add(TEntity entity)
        {
            if (DbSet.Contains(entity) == false)
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                throw new InvalidOperationException("Current entity is already existing in Database");
            }

        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                await DbSet.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }


        public async Task<bool> Remove(int id)
        {
            try
            {

                if (! Exists(id).Result) return false;

                var currentEntityTask = await DbSet.FindAsync(id);
                DbSet.Remove(currentEntityTask!);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> Exists(int id)
        {
            return await DbSet.FindAsync(id) != null;
        }

    }
}


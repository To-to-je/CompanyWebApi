using CompanyWebApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public IQueryable<TEntity> GetAll()
        {
            return DbSet ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            if (await DbSet.Where(predicate).AnyAsync())
            {
                return await DbSet.Where(predicate).Select(e => e).ToListAsync();
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

                await Context.SaveChangesAsync();

            }
            else
            {
                throw new InvalidOperationException("Current entity is already existing in Database");
            }

        }

        public async Task<bool> AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                DbSet.AddRange(entities);
                await Context.SaveChangesAsync();
                return true;
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

                if (!Exists(id).Result) return false;

                var currentEntityTask = await DbSet.FindAsync(id);
                DbSet.Remove(currentEntityTask!);
                await Context.SaveChangesAsync();

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


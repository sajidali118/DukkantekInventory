using Dukkantek.Domain.Entities;
using Dukkantek.EntityFrameWork.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek.Repo.Data
{
    public class GenericRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
          where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly EFContext _dbContext;

        public GenericRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<TEntity> GetAll()
        {

            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(TPrimaryKey id)
        {
            return await _dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<TPrimaryKey> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;


        }

        public async Task Update(TPrimaryKey id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TPrimaryKey id)
        {

            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

        }


    }
    public class GenericRepository<TEntity> : GenericRepository<TEntity, long>, IRepository<TEntity> where TEntity : class, IEntity
    {
        public GenericRepository(EFContext _dbContext) : base(_dbContext)
        {

        }
    }

}
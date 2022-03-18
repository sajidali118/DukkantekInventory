using Dukkantek.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Dukkantek.Repo.Data
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(TPrimaryKey id);

        Task<TPrimaryKey> Create(TEntity entity);

        Task Update(TPrimaryKey id, TEntity entity);

        Task Delete(TPrimaryKey id);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : class, IEntity
    {

    }

}

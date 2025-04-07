
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Interface
{
    public interface IGenaricRepository<TEntity> where TEntity : BaseEntity
    {
         IEnumerable<TEntity> GetAll(bool withTracking = false);
         IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> Selector);
         IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> Predic);
         TEntity GetById(int id);

        void Update(TEntity employee);
        void Remove(TEntity employee);
        void Add(TEntity employee);

        //IEnumerable<TEntity> GetEnumrable();
        //IQueryable<TEntity> GetEQueryable();
    }
}

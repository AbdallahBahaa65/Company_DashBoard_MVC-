
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Interface
{
    public interface IGenaricRepository<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll(bool withTracking = false);
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>> Selector);
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity,bool>> Predic);
        public TEntity GetById(int id);

        public int Update(TEntity employee);
        public int Remove(TEntity employee);
        public int Add(TEntity employee);

        //IEnumerable<TEntity> GetEnumrable();
        //IQueryable<TEntity> GetEQueryable();
    }
}

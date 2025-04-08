using System.Linq.Expressions;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.DataAccess.Repositories.Class
{
    public class GenaricRepository<T>(ApplicationDbContext dbContext) : IGenaricRepository<T> where T : BaseEntity
    {
        #region CRUD Operations

        #region Get Employee By Id 
        public T? GetById(int Id) => dbContext.Set<T>().Find(Id);// the return Can be null 
        #endregion

        #region Get All Operation
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {

            if (WithTracking)
                return dbContext.Set<T>().Where<T>(E => E.IsDeleted != true).ToList();
            else
                return dbContext.Set<T>().Where<T>(E => E.IsDeleted != true).AsNoTracking().ToList();
        }
        #endregion

        #region Update Operation
         public void  Update(T Employee)
        {
            dbContext.Set<T>().Update(Employee);//here Update Locally not in Database 
           
        }
        #endregion

        #region Delete Operation
        public void Remove(T Employee)
        {
            dbContext.Set<T>().Remove(Employee);
        }
        #endregion

        #region Insert Operation 
        public void Add(T Employee)
        {
            dbContext.Set<T>().Add(Employee);
             }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> Selector)
        {
            return dbContext.Set<T>()
                             .Where(E => E.IsDeleted != true)
                            .Select(Selector)
                            .ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Predic)
        {
            return dbContext.Set<T>()
                  .Where(Predic)
                  .ToList();
        }

       




        //public IEnumerable<T> GetEnumrable()
        //{
        //    return dbContext.Set<T>();
        //}

        //public IQueryable<T> GetEQueryable()
        //{
        //    return dbContext.Set<T>();
        //}





        #endregion

        #endregion
    }
}

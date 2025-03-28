using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.DataAccess.Repositories.Class
{
    public class GenaricRepository<T>(ApplicationDbContext dbContext) : IGenaricRepository<T> where T :BaseEntity
    {
        #region CRUD Operations

        #region Get Employee By Id 
        public T? GetById(int Id) => dbContext.Set<T>().Find(Id);// the return Can be null 
        #endregion

        #region Get All Operation
        public IEnumerable<T> GetAll(bool WithTracking = false)
        {

            if (WithTracking)
                return dbContext.Set<T>().ToList();
            else
                return dbContext.Set<T>().AsNoTracking().ToList();
        }
        #endregion

        #region Update Operation
        public int Update(T Employee)
        {
            dbContext.Set<T>().Update(Employee);//here Update Locally not in Database 
            return dbContext.SaveChanges();//here  to Update In Data Base 
                                           // SaveChanges() Return Number of affected Row 
        }
        #endregion

        #region Delete Operation
        public int Remove(T Employee)
        {
            dbContext.Set<T>().Remove(Employee);
            return dbContext.SaveChanges();//Return N of Row Affected 
        }
        #endregion

        #region Insert Operation 
        public int Add(T Employee)
        {
            dbContext.Set<T>().Add(Employee);
            return dbContext.SaveChanges();//Return N of Row Affected 
        }



        #endregion

        #endregion
    }
}

using System.Linq.Expressions;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.DataAccess.Repositories.Class.DepartmentRepositry
{
    public class DepartmentRepo(ApplicationDbContext _dbContext) : IDepartmentRepo
    //This Is Primary Constractor And Dbcontext Also Become Private Field 
    {



        #region CRUD Operations

        #region Get Department By Id 
        public Department? GetById(int Id) => _dbContext.Departments.Find(Id);// the return Can be null 
        #endregion

        #region Get All Operation
        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {

            if (WithTracking)
                return _dbContext.Departments.ToList();
            else
                return _dbContext.Departments.AsNoTracking().ToList();
        }
        #endregion

        #region Update Operation
        public void Update(Department department)
        {
            _dbContext.Departments.Update(department);//here Update Locally not in Database 
           }
        #endregion

        #region Delete Operation
        public int Remove(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();//Return N of Row Affected 
        }
        #endregion

        #region Insert Operation 
        public void Add(Department department)
        {
            _dbContext.Departments.Add(department);
          
        }

        public IEnumerable<Department> GetAll<TResult>(System.Linq.Expressions.Expression<Func<Department, TResult>> Selector)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TResult> IGenaricRepository<Department>.GetAll<TResult>(Expression<Func<Department, TResult>> Selector)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll(Expression<Func<Department, bool>> Predic)
        {
            throw new NotImplementedException();
        }

        void IGenaricRepository<Department>.Remove(Department employee)
        {
            throw new NotImplementedException();
        }


        #endregion

        #endregion



    }
}

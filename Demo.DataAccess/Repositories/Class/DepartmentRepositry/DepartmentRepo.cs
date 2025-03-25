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
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);//here Update Locally not in Database 
            return _dbContext.SaveChanges();//here  to Update In Data Base 
                                            // SaveChanges() Return Number of affected Row 
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
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();//Return N of Row Affected 
        }
        #endregion

        #endregion



    }
}

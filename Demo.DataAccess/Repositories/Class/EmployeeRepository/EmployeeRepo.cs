using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Repositories.Class.EmployeeRepository
{
    public class EmployeeRepo(ApplicationDbContext dbContext) :GenaricRepository<Employee>(dbContext) ,IEmployeeRepo/*, IEmployeeRepo*/
    {
        //#region CRUD Operations

        //#region Get Employee By Id 
        //public Employee? GetById(int Id) => dbContext.Employees.Find(Id);// the return Can be null 
        //#endregion

        //#region Get All Operation
        //public IEnumerable<Employee> GetAll(bool WithTracking = false)
        //{

        //    if (WithTracking)
        //        return dbContext.Employees.ToList();
        //    else
        //        return dbContext.Employees.AsNoTracking().ToList();
        //}
        //#endregion

        //#region Update Operation
        //public int Update(Employee Employee)
        //{
        //    dbContext.Employees.Update(Employee);//here Update Locally not in Database 
        //    return dbContext.SaveChanges();//here  to Update In Data Base 
        //                                    // SaveChanges() Return Number of affected Row 
        //}
        //#endregion

        //#region Delete Operation
        //public int Remove(Employee Employee)
        //{
        //    dbContext.Employees.Remove(Employee);
        //    return dbContext.SaveChanges();//Return N of Row Affected 
        //}
        //#endregion

        //#region Insert Operation 
        //public int Add(Employee Employee)
        //{
        //    dbContext.Employees.Add(Employee);
        //    return dbContext.SaveChanges();//Return N of Row Affected 
        //}

     

        //#endregion

        //#endregion

    }
}

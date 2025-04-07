using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.DataAccess.Repositories.Class
{
    public class UniteOfWork(ApplicationDbContext dbContext, IDepartmentRepo departmentRepo, IEmployeeRepo employeeRepo) : IUniteOfWork
    {
        public IEmployeeRepo EmployeeReposatry  => employeeRepo;
        public IDepartmentRepo DepartmentReposatry => departmentRepo;
        public int SaveChanges()=> dbContext.SaveChanges();
    }
}

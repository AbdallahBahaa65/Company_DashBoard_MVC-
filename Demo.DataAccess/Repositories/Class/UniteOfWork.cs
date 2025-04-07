using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.DataAccess.Repositories.Class
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private readonly Lazy< IDepartmentRepo> _departmentRepo;
        private readonly Lazy< IEmployeeRepo> _employeeRepo    ;
                                                       
        public UniteOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            _departmentRepo=new Lazy<IDepartmentRepo>(()=>new DepartmentRepo(dbContext));
            _employeeRepo=new Lazy<IEmployeeRepo>(()=>new EmployeeRepo(dbContext));

        }
        public IEmployeeRepo EmployeeReposatry  => _employeeRepo.Value;
        public IDepartmentRepo DepartmentReposatry => _departmentRepo.Value;
        public int SaveChanges()=> dbContext.SaveChanges();
    }
}

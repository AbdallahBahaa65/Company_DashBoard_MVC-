using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeSerivces(IEmployeeRepo _employeeRepo) : IEmployeeSerivces
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var departmentList = _employeeRepo.GetAll();

            return departmentList.Select(E=>E.ToEmployeeDto()) ;
        }


        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Dep = _employeeRepo.GetById(id);
            return Dep?.ToDepartmentDetailsDto();
        }
          

        public int CreateEmoplyee(CreateEmploeeDto emploeeDto)
        {
            var  employee = emploeeDto.ToEntity();
            return _employeeRepo.Add(employee);
        }

         
        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            return _employeeRepo.Update(employeeDto.ToEntity());
        }

        public bool DeleteEmplyee(int id)
        {
            throw new NotImplementedException();
        }
    }
}



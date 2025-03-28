using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeSerivces(IEmployeeRepo _employeeRepo) : IEmployeeSerivces
    {
        public IEnumerable<EmployeeDto> GetAll()
        {
            var departmentList = _employeeRepo.GetAll();

            return departmentList.Select(E=>E.ToEmployeeDto()) ;
        }


        public EmployeeDetailsDto? GetDetails(int id)
        {
            var Dep = _employeeRepo.GetById(id);
            return Dep?.ToDepartmentDetailsDto();
        }


        public int AddEmoplyee(CreateEmploeeDto emploeeDto)
        {
            var  employee = emploeeDto.ToEntity();
            return _employeeRepo.Add(employee);
        }


        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            return _employeeRepo.Update(employeeDto.ToEntity());
        }



    }
}



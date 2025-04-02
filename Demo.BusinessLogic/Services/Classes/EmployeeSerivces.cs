using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeSerivces(IEmployeeRepo _employeeRepo, IMapper mapper) : IEmployeeSerivces
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var departmentList = _employeeRepo.GetAll();
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(departmentList);
            
        }


        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Dep = _employeeRepo.GetById(id);
            return Dep  is null ? null : mapper.Map<Employee,EmployeeDetailsDto>(Dep);
        }
          

        public int CreateEmoplyee(CreateEmploeeDto emploeeDto)
        {
            var employee = mapper.Map<CreateEmploeeDto, Employee>(emploeeDto);
            return _employeeRepo.Add(employee);
        }

         
        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            return _employeeRepo.Update(mapper.Map<UpdateEmployeeDto,Employee>(employeeDto));
        }

        public bool DeleteEmplyee(int id)
        {
            var emp = _employeeRepo.GetById(id);

            if (emp != null)
            { 
                emp.IsDeleted = true;
                return _employeeRepo.Update(emp) >0 ? true : false;
            }
            return false;
           
        }
    }
}



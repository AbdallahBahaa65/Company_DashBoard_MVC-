using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeSerivces
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
         int CreateEmoplyee(CreateEmploeeDto emploeeDto);
         int UpdateEmployee(UpdateEmployeeDto employeeDto);
        EmployeeDetailsDto? GetEmployeeById(int id);
        bool DeleteEmplyee(int id);



    }
}
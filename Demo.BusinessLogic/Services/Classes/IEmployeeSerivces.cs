using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;

namespace Demo.BusinessLogic.Services.Classes
{
    public interface IEmployeeSerivces
    {
        IEnumerable<EmployeeDto> GetAll();
        public int AddEmoplyee(CreateEmploeeDto emploeeDto);
        public int UpdateEmployee(UpdateEmployeeDto employeeDto);
        EmployeeDetailsDto GetDetails(int id);



    }
}
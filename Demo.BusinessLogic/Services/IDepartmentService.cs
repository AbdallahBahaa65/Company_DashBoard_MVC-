using Demo.BusinessLogic.DataTransferObjects;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int AddDepartment(CreateDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAll();
        DepartmentDetailsDto GetDetails(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}
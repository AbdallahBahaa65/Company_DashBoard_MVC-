using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;

namespace Demo.BusinessLogic.Services.Interfaces
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
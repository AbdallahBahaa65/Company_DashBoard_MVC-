using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.Factories;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepo departmentRepo) : IDepartmentService
    {

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departmentList = departmentRepo.GetAll();

            return departmentList.Select(D => D.ToDepartmentDto());
        }


        public DepartmentDetailsDto GetDetails(int id)
        {
            var Dep = departmentRepo.GetById(id);

            return Dep is null ? null : Dep.ToDepartmentDetailsDto();
        }


        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return departmentRepo.Add(department);
        }


        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            return departmentRepo.Update(departmentDto.ToEntity());

        }
        public bool DeleteDepartment(int id)
        {

            var department = departmentRepo.GetById(id);

            if (department is null) return false;
            else
            {
                int Result = departmentRepo.Remove(department);
                return Result > 0 ? true : false;
            }
        }

    }
}
        





using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOS;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUniteOfWork _uniteOfWork) : IDepartmentService
    {

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departmentList = _uniteOfWork.DepartmentReposatry.GetAll();

            return departmentList.Select(D => D.ToDepartmentDto());
        }


        public DepartmentDetailsDto? GetDetails(int id)
        {
            var Dep = _uniteOfWork.DepartmentReposatry.GetById(id);

            return Dep?.ToDepartmentDetailsDto();
        }


        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            _uniteOfWork.DepartmentReposatry.Add(department);
            return _uniteOfWork.SaveChanges();
        }


        public int UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
           _uniteOfWork.DepartmentReposatry.Update(departmentDto.ToEntity());
            return _uniteOfWork.SaveChanges();

        }
        public bool DeleteDepartment(int id)
        {

            var department = _uniteOfWork.DepartmentReposatry.GetById(id);

            if (department is null) return false;
            else
            {
                 _uniteOfWork.DepartmentReposatry.Remove(department);
                    return _uniteOfWork.SaveChanges()>0 ? true : false;
            }
        }

    }
}






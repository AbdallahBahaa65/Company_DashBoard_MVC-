using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.AttachmentServices.AttachmentServices;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;
using Demo.DataAccess.Repositories.Class.EmployeeRepository;
using Demo.DataAccess.Repositories.Interface;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeSerivces(IUniteOfWork _uniteOfWork, IMapper mapper, IAttachmentServices _attachmentServices) : IEmployeeSerivces
    {
        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName)
        {


            var employees = _uniteOfWork.EmployeeReposatry.GetAll(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Salary = E.Salary
            });


            IEnumerable<Employee> Employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
                Employees = _uniteOfWork.EmployeeReposatry.GetAll();
            else
                Employees = _uniteOfWork.EmployeeReposatry.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
            var employee = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employees);
            return employee;





            #region Example On IEnumrable 
            //var Result = _employeeRepo.GetEnumrable()
            //       .Where(E => E.IsDeleted != true)
            //       .Select(E => new EmployeeDto()
            //       {
            //           Id = E.Id,
            //           Age = E.Age,
            //           Email = E.Email,
            //       });
            //return Result.ToList();   
            #endregion
            #region Example On IQueryable 
            //var Result = _employeeRepo.GetEQueryable()
            //     .Where(E => E.IsDeleted != true)
            //     .Select(E => new EmployeeDto()
            //     {
            //         Id = E.Id,
            //         Age = E.Age,
            //         Email = E.Email,
            //     });
            //return Result.ToList(); 
            #endregion
        }


        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Dep = _uniteOfWork.EmployeeReposatry.GetById(id);
            return Dep is null ? null : mapper.Map<Employee, EmployeeDetailsDto>(Dep);
        }


        public int CreateEmoplyee(CreateEmploeeDto emploeeDto)
        {
            var employee = mapper.Map<CreateEmploeeDto ,Employee>(emploeeDto);

            if (emploeeDto.ImageName is not null)
            {
                employee.ImageName = _attachmentServices.Upload(emploeeDto.ImageName, "Images");

            }
            _uniteOfWork.EmployeeReposatry.Add(employee);
            return _uniteOfWork.SaveChanges();

        }


        public int UpdateEmployee(UpdateEmployeeDto employeeDto)
        {

            if (employeeDto.Image is not null)
            {
                employeeDto.ImageName = _attachmentServices.Upload(employeeDto.Image , "Images");

            }
            _uniteOfWork.EmployeeReposatry.Update(mapper.Map<UpdateEmployeeDto, Employee>(employeeDto));   

            return _uniteOfWork.SaveChanges();
        }

        public bool DeleteEmplyee(int id)
        {
            var emp = _uniteOfWork.EmployeeReposatry.GetById(id);

            if (emp != null)
            {
                emp.IsDeleted = true;
                _uniteOfWork.EmployeeReposatry.Update(emp);
                return _uniteOfWork.SaveChanges() > 0 ? true : false;
            }
            return false;

        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}



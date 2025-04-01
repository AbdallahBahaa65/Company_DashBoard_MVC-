using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.DataAccess.Models.EmployeeModels;

namespace Demo.BusinessLogic.Factories
{
    public static class EmployeeFactory
    {

        public static EmployeeDto ToEmployeeDto(this Employee D) => new EmployeeDto
        {
            Id = D.Id,
            Name = D.Name,
            Age = D.Age,
            Email = D.Email,
            Salary = D.Salary,
            IsActive = D.IsActive,
            Gender = D.Gender,
            EmployeeType = D.EmployeeType
            
        };


        public static Employee ToEntity(this EmployeeDto Dep) => new Employee()
        {
            //Id = Dep.DeptId,
            Name = Dep.Name,
            Age = Dep.Age,
            Email = Dep.Email,
            Salary = Dep.Salary,
            IsActive = Dep.IsActive,
            Gender = Dep.Gender,
            EmployeeType = Dep.EmployeeType,
           
            
        };



        public static EmployeeDetailsDto ToDepartmentDetailsDto(this Employee Dep) => new EmployeeDetailsDto()
        {
            Id = Dep.Id,
            Name = Dep.Name,
            Address = Dep.Address,
            Age = Dep.Age,
            Email = Dep.Email,
            Salary = Dep.Salary,
            IsActive = Dep.IsActive,
            Gender = Dep.Gender.ToString(),
            EmployeeType = Dep.EmployeeType.ToString()
        };



        public static Employee ToEntity(this CreateEmploeeDto Dep) => new Employee()
        {
            //Id = Dep.DeptId,
            Name = Dep.Name,
            Age = Dep.Age,
            Email = Dep.Email,
            Salary = Dep.Salary,
            IsActive = Dep.IsActive,
            Gender = Dep.Gender,
            EmployeeType = Dep.EmployeeType,
            CreatedBy = 1,
            LastModifiedBy = 1,
            HiringDate = new DateTime(Dep.HiringDate.Year, Dep.HiringDate.Month, Dep.HiringDate.Day)


        };

        public static Employee ToEntity(this UpdateEmployeeDto Dep) => new Employee()
        {
            Id = Dep.Id,
            Name = Dep.Name,
            IsActive = Dep.IsActive,
            Gender = Dep.Gender,
            EmployeeType = Dep.EmployeeType,
            Address = Dep.Address,
            Age = Dep.Age,
            Email = Dep.Email,
            Salary = Dep.Salary,
            CreatedBy = 1,
            LastModifiedBy =1


        };
    }



}


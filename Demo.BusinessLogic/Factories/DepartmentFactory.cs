using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DataTransferObjects;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositories.Class.DepartmentRepositry;

namespace Demo.BusinessLogic.Factories
{
    public static class DepartmentFactory
    {

        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto
            {
                DeptId = D.Id,
                Name = D.Name,
                Description = D.Description,
                DateOfCreation = DateOnly.FromDateTime((DateTime)D.CreatedOn)
            };
        }


        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department Dep)
        {
            return new DepartmentDetailsDto()
            {
                Id = Dep.Id,
                Name = Dep.Name,
                Description = Dep.Description,
                Code = Dep.Code,
                CreatedBy = Dep.CreatedBy,
                CreatedOn = DateOnly.FromDateTime((DateTime)Dep.CreatedOn),
                IsDeleted = Dep.IsDeleted,
                LastModifiedBy = Dep.LastModifiedBy
            };
        }

        public static Department ToEntity(this CreateDepartmentDto Dep)
        {
            return new Department()
            {
                //Id = Dep.DeptId,
                Name = Dep.Name,
                Description = Dep.Description,
                Code = Dep.Code,
                CreatedOn = Dep.DateOfCreation.ToDateTime(new TimeOnly())

            };
        }
        public static Department ToEntity(this UpdateDepartmentDto Dep) => new Department()
        {
            Id = Dep.Id,
            Name = Dep.Name,
            Description = Dep.Description,
            Code = Dep.Code,
            CreatedOn = Dep.DateOfCreation.ToDateTime(new TimeOnly())

        };
    }


}
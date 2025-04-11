using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTO;
using Demo.DataAccess.Models.EmployeeModels;

namespace Demo.BusinessLogic.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                      .ForMember(D => D.Gender, Option => Option.MapFrom(S => S.Gender))
                      .ForMember(D => D.EmployeeType, Option => Option.MapFrom(S => S.EmployeeType))
                      .ForMember(D => D.Department, Option => Option.MapFrom(S => S.Department != null ? S.Department.Name : null))
                      .ForMember(D => D.Image, Option => Option.MapFrom(S => S.ImageName))
                      .ReverseMap();



            CreateMap<Employee, EmployeeDetailsDto>()
                      .ForMember(D => D.Gender, Option => Option.MapFrom(S => S.Gender))
                      .ForMember(D => D.EmployeeType, Option => Option.MapFrom(S => S.EmployeeType))
                      .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => DateOnly.FromDateTime(S.HiringDate)))
                      .ForMember(D => D.Department, Option => Option.MapFrom(S => S.Department != null ? S.Department.Name : null)).ReverseMap();
                      //.ForMember(D => D.Image, Option => Option.MapFrom(S => S.Image));




            CreateMap<UpdateEmployeeDto, Employee>()
                 .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => S.HiringDate.ToDateTime(TimeOnly.MinValue))).ReverseMap();

            CreateMap<CreateEmploeeDto, Employee>()
                .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => S.HiringDate.ToDateTime(TimeOnly.MinValue))).ReverseMap();

        }
    }
}

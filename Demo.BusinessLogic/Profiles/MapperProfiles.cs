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
            CreateMap<Employee, EmployeeDto>().ReverseMap()
                      .ForMember(D => D.Gender, Option => Option.MapFrom(S => S.Gender))
                      .ForMember(D => D.EmployeeType, Option => Option.MapFrom(S => S.EmployeeType));

            CreateMap<Employee, EmployeeDetailsDto>().ReverseMap()
                   .ForMember(D => D.Gender, Option => Option.MapFrom(S => S.Gender))
                      .ForMember(D => D.EmployeeType, Option => Option.MapFrom(S => S.EmployeeType))
            .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => S.HiringDate.ToDateTime(new TimeOnly())));

            CreateMap<Employee,UpdateEmployeeDto>().ReverseMap()
                 .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => S.HiringDate.ToDateTime(new TimeOnly())));

             CreateMap<CreateEmploeeDto,Employee>().ReverseMap()
                 .ForMember(D => D.HiringDate, Option => Option.MapFrom(S => DateOnly.FromDateTime(S.HiringDate)));

        }
    }
}

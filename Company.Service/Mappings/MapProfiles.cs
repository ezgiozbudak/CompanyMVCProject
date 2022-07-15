using AutoMapper;
using Company.Core;
using Company.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Mappings
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Companies, CompaniesDto>().ReverseMap();
            CreateMap<Departments, DepartmentsDto>().ReverseMap();
            CreateMap<TopDepartments, TopDepartmentsDto>().ReverseMap();
            CreateMap<Subdepartments, SubDepartmentsDto>().ReverseMap();
            

        }
    }
}

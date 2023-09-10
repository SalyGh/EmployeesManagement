using AutoMapper;
using EmployeeProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;


namespace BusinessLogicLayer.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {

            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.TotalSalary, act => act.MapFrom(src => src.BasicSalary + src.Allowance));
            CreateMap<EmployeeDto, Employee>();
           
        }
    }
}

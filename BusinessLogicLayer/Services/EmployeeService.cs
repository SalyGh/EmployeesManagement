using AutoMapper;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Interfaces;
using EmployeeProject.Data;
using EmployeeProject.Interfaces;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;





namespace EmployeeProject.Repositories
{
   

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepository _employeeRepository, IMapper mapper) {
            this._employeeRepository = _employeeRepository;
            this.mapper = mapper;
        }
        public bool AddEmployee(EmployeeDto employee)
        {
            // Mapping Manually 
            //Employee emp = new Employee 
            //{

            //	Name = employee.Name,
            //	BasicSalary = employee.BasicSalary,
            //	Allowance = employee.Allowance,
            //	HireDate = employee.HireDate,
            //};

            // Mapping By the use of automapper
            var emp = mapper.Map<Employee>(employee);
            return  _employeeRepository.AddEmployee(emp);
  
        }

        public async Task<bool> DeleteEmployee(Guid Id)
        {
           return await _employeeRepository.DeleteEmployee(Id);
            
           
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees(string? name)
        {

            //Mapping Manually
            //return emp.Select(q => new EmployeeDto
            //{
            //	Id = q.Id,
            //	Name = q.Name,
            //	HireDate = q.HireDate,
            //	Allowance = q.Allowance,
            //	BasicSalary = q.BasicSalary,
            //	TotalSalary = q.BasicSalary + q.Allowance
            //});


            var emp = await _employeeRepository.GetAllEmployees(name);
            var employees = mapper.Map<IEnumerable<EmployeeDto>>(emp);
            return employees ;
		}

       

        public bool UpdateEmployee(EmployeeDto employee)
        {
            // Mapping Manually
            //Employee emp = new Employee
            //{ 
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    BasicSalary = employee.BasicSalary,
            //    Allowance = employee.Allowance,
            //    HireDate = employee.HireDate,
            //};

            //Auto Mapping
           var emp = mapper.Map<Employee>(employee) ;
           return _employeeRepository.UpdateEmployee(emp);
            

        }




        public async Task<EmployeeDto> GetEmployeeById(Guid id)
        {
          
                
       
         var employee = await _employeeRepository.GetEmployeeById(id);

            //EmployeeDto empDto = new EmployeeDto
            //{
            //    Id = employee.Id,
            //    Name = employee.Name,
            //    Allowance = employee.Allowance,
            //    BasicSalary = employee.BasicSalary,
            //    HireDate = employee.HireDate,
            //    TotalSalary = employee.Allowance + employee.BasicSalary,

            //};

            var empDto = mapper.Map<EmployeeDto>(employee);

            return empDto; 
              
        }
		
	}
}

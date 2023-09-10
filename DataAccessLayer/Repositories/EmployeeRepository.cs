using DataAccessLayer.Interfaces;
using EmployeeProject.Data;
using EmployeeProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
       
        public EmployeeRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            
        }
        public bool AddEmployee(Employee employee)
        {
         
            _context.Add(employee);

            return Save();

        }

        public async Task<bool> DeleteEmployee(Guid Id)
        {
            var employee = await _context.Employees.FindAsync(Id);

            _context.Employees.Remove(employee);
            return Save();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(string? name)
        {
            return await _context.Employees
                .Where(e => string.IsNullOrEmpty(name) || e.Name.Contains(name)).ToListAsync();

 

           
        }


        public bool UpdateEmployee(Employee employee)
        {

 
            _context.Update(employee);
            return Save();

        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {


            var employee = await _context.Employees.FindAsync(id);


            return employee;

        }

    }
}

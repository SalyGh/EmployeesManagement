using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetAllEmployees(string name);

        Task<Employee> GetEmployeeById(Guid id);

        bool AddEmployee(Employee employee);

        Task<bool> DeleteEmployee(Guid id);

        bool UpdateEmployee(Employee employee);

        bool Save();
    }
}

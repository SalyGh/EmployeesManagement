using BusinessLogicLayer.DTO;
using EmployeeProject.Models;

namespace EmployeeProject.Interfaces
{
   
    public interface IEmployeeService
   
    {


        Task <IEnumerable<EmployeeDto>> GetAllEmployees(string name); 

        Task<EmployeeDto> GetEmployeeById (Guid id);

        bool AddEmployee(EmployeeDto employee);

         Task<bool> DeleteEmployee(Guid id);

        bool UpdateEmployee(EmployeeDto employee);

        //Task<IEnumerable<EmployeeDto>> SearchByEmployeeName(string name); // DRY!

      
    }
}

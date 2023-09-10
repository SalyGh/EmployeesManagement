using BusinessLogicLayer.DTO;
using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.ViewModels
{
	public class EmployeeViewModel
	{

        public IEnumerable<EmployeeDto>? EmployeesList { get; set; }

		public EmployeeDto employeeDto{ get; set; } // if we have one object that needs to be mapped

	}
}

using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Email Address")]
		public string EmailAddress { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}

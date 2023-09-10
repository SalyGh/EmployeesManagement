using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [MaxLength(50)]
        [RegularExpression("[a-zA-Z ']*" , ErrorMessage = "Please Enter a valid name")]
        public string Name { get; set; }

        public DateTime? HireDate { get; set; }

		[Required(ErrorMessage = "Please Enter Employee's Basic Salary")]
		public decimal BasicSalary { get; set; } //decimal is the most precise compared to float and doubel

        [Range(15, 500)]
		[Required(ErrorMessage = "Please Enter Employee's Allowance")]
		public decimal Allowance { get; set; }

       

    }
}

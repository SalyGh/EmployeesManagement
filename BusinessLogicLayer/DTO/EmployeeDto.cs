using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Name")]
        [MaxLength(50)]
        [RegularExpression("[a-zA-Z ']*", ErrorMessage = "Please Enter a valid name")]
        public string Name { get; set; }

        public DateTime? HireDate { get; set; }

        public decimal BasicSalary { get; set; } //decimal is the most precise compared to float and doubel

        [Range(15, 500)]
        public decimal Allowance { get; set; }

        public decimal TotalSalary { get; set; }
    }
}

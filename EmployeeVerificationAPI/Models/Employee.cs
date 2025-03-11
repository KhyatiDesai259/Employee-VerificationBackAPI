using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVerificationAPI.Models
{
    public class Employee
    {
        [Key]
        public int inEmployeeId { get; set; }

        [Required]
        public string stCompanyName { get; set; }

        [Required]  
        public string stVerificationCode { get; set; }
    }
}

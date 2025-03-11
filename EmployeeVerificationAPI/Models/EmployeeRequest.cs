namespace EmployeeVerificationAPI.Models
{
    public class EmployeeRequest
    {
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string VerificationCode { get; set; }

    }
}

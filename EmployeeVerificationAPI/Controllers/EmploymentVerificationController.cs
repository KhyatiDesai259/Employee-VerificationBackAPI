using Azure.Core;
using EmployeeVerificationAPI.Data;
using EmployeeVerificationAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVerificationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmploymentVerificationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmploymentVerificationController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("verify-employment")]
        public async Task<IActionResult> VerifyEmployment([FromBody] EmployeeRequest objEmployeeRequest)
        {
            try
            {
                if (objEmployeeRequest == null || string.IsNullOrEmpty(objEmployeeRequest.VerificationCode) || string.IsNullOrEmpty(objEmployeeRequest.CompanyName))
                    return BadRequest(new { Status = "This is Invalid Request!" });

                var employee = await _context.tblEmployees
                                       .FirstOrDefaultAsync(e => e.inEmployeeId == objEmployeeRequest.EmployeeId &&
                                       e.stCompanyName == objEmployeeRequest.CompanyName &&
                                       e.stVerificationCode == objEmployeeRequest.VerificationCode);

                if (employee != null)
                    return Ok(new { Status = "Employee is Verified" });
                else
                    return Ok(new { Status = "Employee is Not Verified" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new { Status = "Please try again later!", Message = ex.Message.ToString() });
            }
        }

    }
}

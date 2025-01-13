using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LVRCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LVRCalController : ControllerBase
    {
        [HttpPost]
        public ActionResult<decimal> CalculateLvr([FromBody] LvrRecordRequest request)
        {
            // Validate the input in LVR Calculator
            if (request.PropertyValue <= 0)
            {
                return BadRequest("Property value must be greater than zero.");
            }

            if(request.LoanAmount <= 0)
            {
                return BadRequest("Loan Amount must be greater than zero.");
            }

            // Calculate LVR
            decimal lvrResult = Math.Round((request.LoanAmount / request.PropertyValue) * 100, 2);

            // Return the result
            return Ok(lvrResult);
        }
    }


    public class LvrRecordRequest
    {
        public decimal LoanAmount { get; set; }
        public decimal PropertyValue { get; set; }
        
    }
}

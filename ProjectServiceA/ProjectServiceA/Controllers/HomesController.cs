using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectServiceA.Models;
using ProjectServiceA.Service;

namespace ProjectServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public HomesController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetDatabase")]
        public async Task<IActionResult> GetDatabase()
        {
            try
            {
                var result = await _customerService.GetDatabase();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

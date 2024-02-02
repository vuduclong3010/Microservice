using Microsoft.AspNetCore.Mvc;
using ProjectServiceB.Models;
using ProjectServiceB.Service;

namespace ProjectServiceB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly IHandleDatabaseService _handleDatabase;

        public HomesController(IHandleDatabaseService handleDatabase)
        {
            _handleDatabase = handleDatabase;
        }

        [HttpGet("InsertOrUpdateDatabase")]
        public async Task<IActionResult> InsertDatabase()
        {
            return Ok(await _handleDatabase.HandleDatabaseTable("http://localhost:5095/api/Homes/GetDatabase"));
        }
    }
}

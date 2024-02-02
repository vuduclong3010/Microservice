using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectServiceB.Service;

namespace ProjectServiceB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly IInsertOrUpdateService _insertDatabase;

        public HomesController(IInsertOrUpdateService insertDatabase)
        {
            _insertDatabase = insertDatabase;
        }

        [HttpGet]
        public async Task<IActionResult> InsertDatabase()
        {
            return Ok(_insertDatabase.InsertOrUpdateDatabase("http://localhost:5095/api/Homes/GetDatabase"));
        }
    }
}

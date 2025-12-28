using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthTestController : ControllerBase
    {
        private readonly ILogger<HealthTestController> _logger;
        public HealthTestController(ILogger<HealthTestController> logger)
        {
            _logger = logger;
        }


        [HttpGet("{word}")]
        public ActionResult Echo([FromRoute ]string word)

        {
            _logger.LogInformation("Echoing word: {word}", word);   
            return StatusCode(202, new { word});
        }
    }
}

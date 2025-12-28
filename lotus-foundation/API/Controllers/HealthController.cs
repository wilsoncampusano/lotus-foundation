using Infraestructure.Persistence.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly MongoHealthCheck _mongo;
        public HealthController(ILogger<HealthController> logger,
                                MongoHealthCheck mongo)
        {
            _logger = logger;
            _mongo = mongo;
        }


        [HttpGet("{word}")]
        public ActionResult Echo([FromRoute ]string word)

        {
            _logger.LogInformation("Echoing word: {word}", word);   
            return StatusCode(202, new { word});
        }


        [HttpGet("mongo")]
        public async Task<IActionResult> Mongo()
        {
            var ok = await _mongo.CheckAsync();
            return ok ? Ok("Mongo OK") : StatusCode(500);
        }
    }
}

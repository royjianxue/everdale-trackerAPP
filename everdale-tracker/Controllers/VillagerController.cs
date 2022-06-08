using Microsoft.AspNetCore.Mvc;

namespace everdale_tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VillagerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<VillagerController> _logger;

        public VillagerController(ILogger<VillagerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Villager> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Villager
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
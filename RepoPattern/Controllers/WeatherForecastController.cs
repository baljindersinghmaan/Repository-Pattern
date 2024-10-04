using Microsoft.AspNetCore.Mvc;
using Repo_Pattern.RepoPattern;

namespace RepoPattern.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRepository<Author,string >_db;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<Author , string> author)
    {
        _logger = logger;
        _db = author;
    }

    [HttpPost("")]
    public Author AddAuthor([FromBody] Author author)
    {
        
         _db.Create(author);
        return author;
    }

    [HttpGet("authors")]
    public IList<Author> GetAuthor()
    {
        return _db.GetAll();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

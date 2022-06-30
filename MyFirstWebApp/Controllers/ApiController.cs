using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static MyFirstWebApp.Services.Contracts.IjokeServise;

namespace MyFirstWebApp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IJokeServise _jokeServise;

        public ApiController(IJokeServise jokeServise)
        {
            _jokeServise = jokeServise;
        }


        [HttpGet("API/Jokes/Quantity/{q}")]
        public async Task<string> Jokes(int q)
        {
            return JsonSerializer.Serialize(await _jokeServise.GetNumberOfRandomJokes(q));
        }

        [HttpGet("API/Jokes")]
        public async Task<string> Jokes()
        {
            return JsonSerializer.Serialize(await _jokeServise.GetRandomJoke());
        }

    }
}

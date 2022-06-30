using Microsoft.AspNetCore.Mvc;
using MyFirstWebApp.Models;
using System.Diagnostics;
using static MyFirstWebApp.Services.Contracts.IjokeServise;

namespace MyFirstWebApp.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        

        private readonly IJokeServise _jokeServise;
             public HomeController(IJokeServise jokeServise)
        {
            _jokeServise = jokeServise;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Jokes()
        {
            var jokes = new JokeModel(await _jokeServise.GetRandomJoke());
            return View(jokes);
        }


        [Route("/Home/Jokes/Quantity/{q}")]
        public async Task <IActionResult> Jokes(int q)
        {
            var jokes = new JokeModel( await _jokeServise.GetNumberOfRandomJokes(q));
            return View(jokes);
        }

        public IActionResult Processors()
        {
            return View();
        }

        public IActionResult BookStore()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
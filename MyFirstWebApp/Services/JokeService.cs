using MyFirstWebApp.Classes;
using Newtonsoft.Json;
using static MyFirstWebApp.Services.Contracts.IjokeServise;
using static MyFirstWebApp.Services.Contracts.ILoggerService;

namespace MyFirstWebApp.Services
{

    //skirtas susirinkt is API jokes
    public class JokeServise : IJokeServise
    {
        private string _dadJokeUrl = "https://icanhazdadjoke.com/";

        private readonly ILoggerServise _logger;

        public JokeServise(ILoggerServise logger)
        {
            _logger = logger;
        }

        public async Task<DadJoke> GetRandomJoke()
        {
            //var joke = await GetDadJoke();

            return await GetDadJoke();
        }

        public async Task<string> GetJoke(string jokeId)
        {
            var joke = await GetDadJoke(jokeId);

            return joke.Joke;
        }

        private async Task<DadJoke> GetDadJoke(string id = "")
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            try
            {
                var result = await client.GetAsync(string.IsNullOrEmpty(id)
                    ? _dadJokeUrl
                    : $"{_dadJokeUrl}j/{id}");

                result.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<DadJoke>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                await _logger.LogWarning($"Cannot reach {_dadJokeUrl}");
                await _logger.LogWarning($"error: {ex.Message} \nTrace: {ex.StackTrace}");

                return null;
            }
        }


        public async Task<DadJoke[]> GetNumberOfRandomJokes(int quantity)
        {
            var jokeArray = new DadJoke[quantity];

            for (int i = 0; i < quantity; i++)
            {
                jokeArray[i] = await GetRandomJoke();
            }

            return jokeArray;
        }

    }
}

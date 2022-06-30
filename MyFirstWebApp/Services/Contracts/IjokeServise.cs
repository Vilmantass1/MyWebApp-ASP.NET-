using MyFirstWebApp.Classes;

namespace MyFirstWebApp.Services.Contracts
{
    public class IjokeServise
    {

        public interface IJokeServise
        {
            public Task<DadJoke> GetRandomJoke();

            public Task<string> GetJoke(string jokeId);

            public Task<DadJoke[]> GetNumberOfRandomJokes(int q);
        }
    }
}

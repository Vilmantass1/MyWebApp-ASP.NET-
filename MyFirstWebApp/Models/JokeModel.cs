using MyFirstWebApp.Classes;

namespace MyFirstWebApp.Models
{
    public class JokeModel
    {

        public string Title { get; set; } = "Jokes";
        public string Description { get; set; } = "This is where we will show jokes from API";

        public DadJoke[] Jokes { get; set; }
        public JokeModel(DadJoke joke)
        {
            Jokes = new DadJoke[] { joke };
        }

        public JokeModel(DadJoke[] jokes)
        {
            Jokes = jokes;
        }

    }

    
}

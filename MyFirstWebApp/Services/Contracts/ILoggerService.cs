namespace MyFirstWebApp.Services.Contracts
{
    public class ILoggerService
    {
        public interface ILoggerServise
        {
            public Task LogWarning(string message);

            public Task LogError(string message);

            public Task LogInfo(string message);

            public Task LogDebug(string message);
        }

    }
}

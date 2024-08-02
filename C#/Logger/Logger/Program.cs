namespace Logger
{   public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class App
    {
        private ILogger _logger;
        public App(ILogger logger)
        {
            _logger = logger;
        }
        public void Log(string message) { 
            _logger.Log(message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new FileLogger();
            App a = new App(log);
            a.Log("hey");
            Console.ReadKey();
        }
    }
}

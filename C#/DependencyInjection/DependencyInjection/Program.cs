namespace DependencyInjection
{
    public class injector
    {
        public void inject()
        {
            Console.WriteLine("Dependency injected");
        }
    }
    public class main
    {
        public injector _injector { get; set; }

        public main(injector inject) {
            _injector = inject;
        }

        public void main_run() {
            _injector.inject();
            Console.WriteLine("Injected");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {   injector i = new injector();
            main m = new main(i);
            m.main_run();
            Console.ReadKey();
        }
    }
}

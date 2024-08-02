namespace Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            dog mydog = new dog();
            mydog.eat();
            Console.ReadKey();
        }
    }
    public class animal
    {

        public virtual void eat()
        {
            Console.WriteLine("ewff");
        }
    }

    public class dog : animal { 
        public override void eat() { 
            base.eat();
            Console.WriteLine("eflwf"); }

    }
}

using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)

        {   
            Class1 cl1 = new Class1(Console.ReadLine() , false);
            cl1.Model = "Verna";
            Console.WriteLine(cl1.Id);
            Console.ReadKey();
        }
    }
}

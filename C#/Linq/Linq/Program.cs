using System.Runtime.InteropServices;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] id = new int[] { 1, 2, 3 };
            string[] name = new string[] { "a", "b", "c" };

            var query = from id join name 

            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}

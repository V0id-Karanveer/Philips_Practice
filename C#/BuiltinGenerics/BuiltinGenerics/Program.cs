namespace BuiltinGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Action<int> ac = (x) =>
            {
                Console.WriteLine(x + 10);
            };


            Action<float, float> ac2 = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
            ac2(10,12);*/

            /*Func<int , int> fn = (x) => x+10;
            Console.WriteLine(fn(10));
            Console.ReadKey();*/

            Predicate<int> p = (x) => x%2 == 0;

            List<int> list = new List<int>()
            {
                1,2,3,4,5
            };

            var evens = list.FindAll(p);

            foreach (int i in evens) { 
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}

using System.Reflection;
namespace Generic_prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            repo<int> r = new repo<int>();
            r.Id = 1;
            r.print(1);

            Type t = typeof(repo<>);
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }

    interface IInterface<T> {
        int Id { get; set; }
    }
    
    class repo<t> : IInterface<t>
    {
        public int Id {  get; set; }

        public void print(t t1)
        {
            Console.WriteLine(Id+" obj is "+t1.ToString());
        }
    }
}

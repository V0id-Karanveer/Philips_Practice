namespace lists
{
    public class prod
    {
        public int id { get; set; }
        public int price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ls = new List<int>();
            ls = [1, 2, 3, 4, 1];
            ls.Sort();
            Predicate<int> p = x => x > 2;
            List<int> ls2 = ls.Where(x => x>2).ToList();
            foreach (int i in ls2)
            {
                Console.WriteLine(i);
            }

            List<prod> p1 = new List<prod>
            {
                new prod{id = 1 , price = 1 },
                new prod{id = 2 , price = 2}
            };

            foreach (prod x in p1)
            {
                Console.Write(x.id + " " + x.price);
            }
            Console.ReadKey();

        }
    }
}

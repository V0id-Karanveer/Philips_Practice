namespace TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = 0;
                if (x == 0)
                {
                    throw new Exception("0");
                }
                Console.WriteLine(2 / x);
                
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Done");
            }

            Console.ReadKey();
        }
    }
}

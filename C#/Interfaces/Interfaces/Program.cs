using System.Security.Cryptography;

namespace Interfaces
{
    public interface IPaymentProc
    {
        void Process(decimal amount);
    }

    public class paypal : IPaymentProc
    {
        public void Process(decimal amount)
        {
            Console.WriteLine("paypal amout : "+amount);
        }

    
    }

    public class hdfc : IPaymentProc
    {
        public void Process(decimal amount)
        {
            Console.WriteLine("hdfc amout : " + amount);
        }


    }

    public class service
    {
        private IPaymentProc proc;
        public service(IPaymentProc proc)
        {
            this.proc = proc;
        }

        public void process_service(decimal amount) { 
            proc.Process(amount);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            IPaymentProc paypal = new paypal();
            IPaymentProc hdfc = new hdfc();
            service s = new service(hdfc);
            s.process_service(100.00m);
            Console.ReadKey();
        }
    }
}

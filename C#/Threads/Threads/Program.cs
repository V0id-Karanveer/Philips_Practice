namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("wlnfefr");
            Thread.Sleep(1000);*/

            /*var taskcompletion = new TaskCompletionSource<bool>();
            

            var thread = new Thread(() =>{
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                taskcompletion.SetResult(true);
            });

            thread.Start();


            var res = taskcompletion.Task.Result;

            Console.WriteLine(res);*/

            /*Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                new Thread(() =>
                {
                    Console.WriteLine("starting thread" + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                    Console.WriteLine("ending thread" + Thread.CurrentThread.ManagedThreadId);

                }).Start();
            });*/

            /*Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine("starting thread" + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(1000);
                    Console.WriteLine("ending thread" + Thread.CurrentThread.ManagedThreadId);
                });
            });*/


            var thread1 = new 

            

            

            Console.ReadKey();
        }

        public void thread


    }
}

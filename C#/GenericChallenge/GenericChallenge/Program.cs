namespace GenericChallenge
{
    interface ITask<T>
    {
        T perform();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailTask etask = new EmailTask("Karanveer" , "Hello");
            ReportTask rtask = new ReportTask("Error");

            TaskProcessor<EmailTask, string> t1 = new TaskProcessor<EmailTask, string>(etask);
            TaskProcessor<ReportTask, string> t2 = new TaskProcessor<ReportTask, string>(rtask);

            Console.WriteLine(t1.Execute());

            Console.WriteLine(t2.Execute());


            Console.ReadKey();
        }
    }

    class EmailTask : ITask<string>
    {
        public string Recipient { get; set; }
        public string Message { get; set; }

        public EmailTask(string reco , string mess)
        {
            Recipient = reco;
            Message = mess;
        }
        public string perform()
        {
            return Recipient + ": " + Message;
        }
    }

    class ReportTask : ITask<string>
    {
        public string ReportName { get; set; }

        public ReportTask(string reportName)
        {
            ReportName = reportName;
        }
        public string perform()
        {
            return "Report: " + ReportName;
        }
    }

    class TaskProcessor<TTask, TResult> where TTask : ITask<TResult>
    {
        public TTask task { get; set; }

        public TaskProcessor(TTask task)
        {
            this.task = task;
        }
        public TResult Execute()
        {
            return task.perform();
        }
    }
}

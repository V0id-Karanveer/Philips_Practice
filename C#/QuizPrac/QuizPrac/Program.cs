namespace QuizPrac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions[] questions = new Questions[] {
                new Questions("first ques" , new string[] {"A","B","C","D"} , 2),
                new Questions("2nd ques" , new string[] {"A","B","C","D"} , 1)
            };
            quiz q = new quiz(questions);
            q.start_quiz();

            Console.ReadKey();
        }
    }
}

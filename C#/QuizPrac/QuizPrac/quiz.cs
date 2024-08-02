using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPrac
{
    internal class quiz
    {
        private Questions[] ques;
        private int score  = 0;
        public quiz(Questions[] ques)
        {
            this.ques = ques;
        }

        public void start_quiz()
        {
            int qno = 1;
            for (int i = 0; i < ques.Length; i++)
            {   Console.Write("\n\n"+qno++ + " ");
                if (disp_ques(ques[i]))
                {
                    score++;
                }

            }
            Console.WriteLine($"Quiz over, score is {score} / {ques.Length}");
            Console.WriteLine($"% is {(double)(score * 100) / ques.Length}");
        }

        private bool disp_ques(Questions ques1)
        {
            Console.WriteLine(ques1.ques);
            for (int i = 0; i < ques1.ans.Length; i++) {
                Console.WriteLine($"\n{(i+1)}. {ques1.ans[i]}");    
            }
            int ch = get_choice();
            if (ques1.isCorrect(ch))
            {
                Console.WriteLine("Correct ans");
                return true;
            }
            else
            {
                Console.WriteLine("Wrong , correct ans is " + ques1.ans[ques1.corr_ans - 1]);
                return false;
            }
            
        }

        private int get_choice()
        {
            Console.Write("Enter choice: ");
            string inp = Console.ReadLine();
            int ch;
            while(!int.TryParse(inp , out ch) || ch<1 || ch> 4)
            {
                Console.Write("try again: ");
                inp = Console.ReadLine();
            }

            return ch;
            
        }
    }
}

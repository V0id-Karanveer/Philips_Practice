using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPrac
{
    internal class Questions
    {
        public string ques { get; set; }
        public string[] ans { get; set; }
        public int corr_ans {  get; set; }

        public Questions(string ques , string[] ans , int corr_ans) 
        {
            this.ques = ques;
            this.ans = ans;
            this.corr_ans = corr_ans;
        }

        public bool isCorrect(int given)
        {
            return given == corr_ans;
        }

    }
}

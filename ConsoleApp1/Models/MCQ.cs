using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class MCQ : Question
    {
        public MCQ(string header, string body, int mark, List<Answer> answers, Answer correctAnswer) 
            : base(header, body, mark, answers, correctAnswer)
        {

        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} \n {Body}");
            foreach (var ans in Answers)
            {
                Console.WriteLine($"{ans.AnswerId}. {ans.AnswerText}");
            }
        }
    }
}

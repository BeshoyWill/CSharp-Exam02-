using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class TrueFalse : Question
    {
        public TrueFalse(string header, string body, int mark, Answer correctAnswer) 
        : base(header, body, mark, new List<Answer> { new Answer(1, "True"), new Answer(2, "False") }, correctAnswer)
        {
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} \n {Body} \n 1. True \t 2. False");

            foreach (var answer in Answers)
            {
                Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
            }
        }
    }
}

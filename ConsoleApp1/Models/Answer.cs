using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }
    }
}

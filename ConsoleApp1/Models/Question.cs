using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public abstract class Question : ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        protected Question(string header, string body, int mark, List<Answer> answers, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public bool IsCorrect(int userChoice) => userChoice == CorrectAnswer.AnswerId;

        public abstract void DisplayQuestion();

        public object Clone()
        {
            return new MCQ(Header, Body, Mark, new List<Answer>(Answers), CorrectAnswer);
        }

        public override string ToString()
        {
            string questionText = $"{Header}: {Body} ({Mark} Marks)\n";
            foreach (var answer in Answers)
            {
                questionText += $"{answer.AnswerId}. {answer.AnswerText}\n";
            }
            return questionText;
        }
    }
}

using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Exams
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumOfQuestions { get; set; }
        public List<Question> Question { get; set; }

        protected Exam(int time, int numOfQuestions, List<Question> question)
        {
            Time = time;
            NumOfQuestions = numOfQuestions;
            Question = question;
        }

        public abstract void ShowExam();
    }
}

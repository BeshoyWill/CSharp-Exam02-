using ConsoleApp1.Models;
using ConsoleApp1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1.Exams
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numOfQuestions, List<Question> question)
            : base(time, numOfQuestions, question)
        {

        }
        public override void ShowExam()
        {
            int score = 0;
            Console.WriteLine("===== Practical Exam =====");

            List<Question> clonedQuestions = Question.Select(q => (Question)q.Clone()).ToList();
            clonedQuestions.Sort(new QuestionComparer());

            foreach (var question in clonedQuestions)
            {
                Console.WriteLine(question);
                Console.Write("Your Answer: ");
                int userAnswer = int.Parse(Console.ReadLine() ?? "0");

                if (question.IsCorrect(userAnswer))
                {
                    score += question.Mark;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer is: {question.CorrectAnswer.AnswerText}");
                }
            }

            Console.WriteLine($"\n===== Exam Finished! =====");
            Console.WriteLine($"Your Final Score: {score} / {Question.Sum(q => q.Mark)}");
        }
    }
}

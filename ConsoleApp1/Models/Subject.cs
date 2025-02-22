using ConsoleApp1.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }


        public void CreateExam()
        {
            int examType = GetUserInput("Enter Exam Type (1: Practical, 2: Final): ", 1, 2);
            int duration = GetUserInput("Enter Exam Duration (in minutes): ", 1, 180);
            int numQuestions = GetUserInput("Enter Number of Questions: ", 1, 20);

            List<Question> questions = new List<Question>();

            for (int i = 1; i <= numQuestions; i++)
            {
                Console.WriteLine($"\nCreating Question {i}:");
                questions.Add(CreateQuestion(examType));
            }

            Exam = examType == 1
                ? new PracticalExam(duration, numQuestions, questions)
                : new FinalExam(duration, numQuestions, questions);

            Console.WriteLine("\nExam Created Successfully!\n");
        }

        private Question CreateQuestion(int examType)
        {
            if (examType == 1) // Practical Exam → Only MCQ
                return CreateMCQQuestion();
            else // Final Exam → MCQ or True/False
            {
                int questionType = GetUserInput("Select Question Type (1: True/False, 2: MCQ): ", 1, 2);
                return questionType == 1 ? CreateTrueFalseQuestion() : CreateMCQQuestion();
            }
        }

        private Question CreateMCQQuestion()
        {
            string header = GetUserInputString("Enter Question Header:");
            string body = GetUserInputString("Enter Question Body:");
            int marks = GetUserInput("Enter Marks for This Question: ", 1, 10);

            List<Answer> answers = new List<Answer>();
            for (int j = 1; j <= 3; j++)
            {
                answers.Add(new Answer(j, GetUserInputString($"Enter Answer {j}: ")));
            }

            int correctIndex = GetUserInput("Enter the Correct Answer Number (1-3): ", 1, 3);
            return new MCQ(header, body, marks, answers, answers[correctIndex - 1]);
        }

        private Question CreateTrueFalseQuestion()
        {
            string header = GetUserInputString("Enter Question Header:");
            string body = GetUserInputString("Enter Question Body:");
            int marks = GetUserInput("Enter Marks for This Question: ", 1, 10);
            int correctAnswer = GetUserInput("Enter Correct Answer (1: True, 2: False): ", 1, 2);

            return new TrueFalse(header, body, marks, new Answer(correctAnswer, correctAnswer == 1 ? "True" : "False"));
        }

        private int GetUserInput(string prompt, int min, int max)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write($"Invalid input! Enter a number between {min}-{max}: ");
            }
            return value;
        }

        private string GetUserInputString(string prompt)
        {
            Console.Write(prompt + " ");
            return Console.ReadLine() ?? "";
        }

    }
}
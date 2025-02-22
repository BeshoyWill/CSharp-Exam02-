using ConsoleApp1.Exams;
using ConsoleApp1.Models;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Sub1 = new Subject(10, "c#");
            Sub1.CreateExam();

            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam (y | n): ");

            if (char.Parse(Console.ReadLine()) == 'y' )
            {
                Stopwatch  SW = new Stopwatch();
                SW.Start();
                Sub1.Exam.ShowExam();
                Console.WriteLine($"The Elapsed Time = {SW.Elapsed}");
            }
        }
    }
}

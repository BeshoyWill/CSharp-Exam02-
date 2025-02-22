using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utilities
{
    public class QuestionComparer : IQuestionComparer
    {
        public int Compare(Question? x, Question? y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return y.Mark.CompareTo(x.Mark);
        }
    }
}

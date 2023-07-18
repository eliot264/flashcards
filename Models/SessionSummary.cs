using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class SessionSummary
    {
        public int CorrectAnswers { get; set; }
        public int AllAnswers { get; set; }
        public TimeSpan Time { get; set; }

        public SessionSummary(int correctAnswers, int allAnswers, TimeSpan time)
        {
            CorrectAnswers = correctAnswers;
            AllAnswers = allAnswers;
            Time = time;
        }
    }
}

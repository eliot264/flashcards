using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Models
{
    public class Card
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public Card(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}

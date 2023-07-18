using Flashcards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.ViewModels
{
    public class CardViewModel
    {
        private readonly Card _card;
        public string Question => _card.Question;
        public string Answer => _card.Answer;

        public CardViewModel(Card card)
        {
            _card = card;
        }
    }
}

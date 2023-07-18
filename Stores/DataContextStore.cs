using Flashcards.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Stores
{
    public class DataContextStore
    {
        private FlashcardContext _currentContext;
        public FlashcardContext CurrentContext
        {
            get => _currentContext;
            set
            {
                _currentContext = value;
            }
        }

        public DataContextStore(FlashcardContext currentContext)
        {
            _currentContext = currentContext;
        }
    }
}

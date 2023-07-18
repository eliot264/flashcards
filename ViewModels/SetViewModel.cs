using Flashcards.Commands;
using Flashcards.Models;
using Flashcards.Services;
using Flashcards.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class SetViewModel
    {
        private readonly Set _set;
        private ObservableCollection<CardViewModel> _cards;

        public string Name => _set.Name;
        public string Description => _set.Description;
        public ICollection<CardViewModel> Cards => _cards;
        public int NumberOfCards => _set.NumberOfCards;
        public ICommand StartSessionCommand { get; }

        public SetViewModel(Set set, DataContextStore dataContextStore, NavigationStore navigationStore)
        {
            _set = set;
            _cards = new ObservableCollection<CardViewModel>();
            if (set != null)
            {
                if(set.Cards != null)
                {
                    foreach (var card in set.Cards)
                    {
                        _cards.Add(new CardViewModel(card));
                    }
                }
            }

            NavigationService<SessionViewModel> navigationService = new NavigationService<SessionViewModel>(navigationStore, () => new SessionViewModel(navigationStore, dataContextStore, set));
            StartSessionCommand = new NavigateCommand<SessionViewModel>(navigationService);
        }
    }
}

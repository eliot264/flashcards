using Flashcards.Commands;
using Flashcards.Data;
using Flashcards.Models;
using Flashcards.Services;
using Flashcards.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class SessionSummaryViewModel : ViewModelBase
    {
        private readonly SessionSummary _sessionSummary;
        public int CorrectAnswers => _sessionSummary.CorrectAnswers;
        public int AllAnswers => _sessionSummary.AllAnswers;
        public TimeSpan Time => _sessionSummary.Time;

        public ICommand GoToSetListingCommand { get; }

        public SessionSummaryViewModel(SessionSummary sessionSummary, NavigationStore navigationStore, DataContextStore dataContextStore)
        {
            _sessionSummary = sessionSummary;

            NavigationService<SetListingViewModel> navigationService = new NavigationService<SetListingViewModel>(navigationStore, () => new SetListingViewModel(dataContextStore, navigationStore));
            GoToSetListingCommand = new NavigateCommand<SetListingViewModel>(navigationService);
        }
    }
}

using Flashcards.Commands;
using Flashcards.Models;
using Flashcards.Services;
using Flashcards.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Flashcards.ViewModels
{
    public class SessionViewModel : ViewModelBase
    {
        private readonly Set _set;
        private readonly int[] _order;
        private readonly DispatcherTimer _timer;

        private int currentCardNumber;
        private int correctAnswers;
        private TimeSpan time;

        public string Question => _set.Cards.ElementAt(_order[currentCardNumber]).Question;
        public string Answer => _set.Cards.ElementAt(_order[currentCardNumber]).Answer;
        public int CorrectAnswers => correctAnswers;
        public int NumberOfCards => _set.Cards.Count;
        public TimeSpan Time => time;

        public ICommand CorrectAnswerCommand { get; }
        public ICommand IncorrectAnswerCommand { get; }
        public ICommand GoToSetListingCommand { get; }

        public SessionViewModel(NavigationStore navigationStore, DataContextStore dataContextStore, Set set)
        {
            _set = set;
            _order = InitializeOrder();
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1),
            };

            time = TimeSpan.Zero;

            _timer.Tick += new EventHandler(TimerTick);
            _timer.Start();

            ParameterNavigationService<SessionSummary, SessionSummaryViewModel> navigationService = new ParameterNavigationService<SessionSummary, SessionSummaryViewModel>(navigationStore, (parameter) => new SessionSummaryViewModel(parameter, navigationStore, dataContextStore));
            CorrectAnswerCommand = new CorrectAnswerCommand(this, navigationService);
            IncorrectAnswerCommand = new IncorrectAnswerCommand(this, navigationService);

            GoToSetListingCommand = new NavigateCommand<SetListingViewModel>(new NavigationService<SetListingViewModel>(navigationStore, () => new SetListingViewModel(dataContextStore, navigationStore)));
        }

        private int[] InitializeOrder() // Fisher-Yates shuffle
        {
            int[] order = new int[NumberOfCards];
            List<int> original = Enumerable.Range(0, NumberOfCards).ToList();
            Random r = new Random();

            for (int i = 0; i < NumberOfCards; i++)
            {
                int j = r.Next(0, original.Count);
                order[i] = original[j];
                original.RemoveAt(j);
            }

            return order;
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            time += TimeSpan.FromSeconds(1);
            OnPropertyChanged(nameof(Time));
        }

        private void UpdateCard()
        {
            OnPropertyChanged(nameof(Question));
            OnPropertyChanged(nameof(Answer));
        }

        public void UpdateCorrectAnswers()
        {
            correctAnswers++;
            currentCardNumber++;

            OnPropertyChanged(nameof(CorrectAnswers));
            UpdateCard();
        }

        public void UpdateIncorrectAnswers()
        {
            currentCardNumber++;
            UpdateCard();
        }

        public bool IsFinished()
        {
            if(currentCardNumber == (NumberOfCards - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

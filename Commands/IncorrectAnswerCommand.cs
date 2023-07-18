using Flashcards.Models;
using Flashcards.Services;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class IncorrectAnswerCommand : CommandBase
    {
        private readonly SessionViewModel _sessionViewModel;
        private readonly ParameterNavigationService<SessionSummary, SessionSummaryViewModel> _navigationService;

        public IncorrectAnswerCommand(SessionViewModel sessionViewModel, ParameterNavigationService<SessionSummary, SessionSummaryViewModel> navigationService)
        {
            _sessionViewModel = sessionViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            if (_sessionViewModel.IsFinished())
            {
                SessionSummary sessionSummary = new SessionSummary(_sessionViewModel.CorrectAnswers, _sessionViewModel.NumberOfCards, _sessionViewModel.Time);
                _navigationService.Navigate(sessionSummary);
            }
            else
            {
                _sessionViewModel.UpdateIncorrectAnswers();
            }
        }
    }
}

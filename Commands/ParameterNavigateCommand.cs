using Flashcards.Services;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class ParameterNavigateCommand<TParameter, TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly ParameterNavigationService<TParameter, TViewModel> _navigationService;
        private readonly TParameter _parameter;

        public ParameterNavigateCommand(ParameterNavigationService<TParameter, TViewModel> navigationService, TParameter parameter)
        {
            _navigationService = navigationService;
            _parameter = parameter;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_parameter);
        }
    }
}

using Flashcards.Commands;
using Flashcards.Data;
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
    public class MenuViewModel : ViewModelBase
    {
        public ICommand GoToSetListingViewCommand { get; }
        public ICommand ExitCommand { get; }

        public MenuViewModel(NavigationStore navigationStore, DataContextStore dataContextStore)
        {
            NavigationService<SetListingViewModel> navigationService = new NavigationService<SetListingViewModel>(navigationStore, () => new SetListingViewModel(dataContextStore, navigationStore));
            GoToSetListingViewCommand = new NavigateCommand<SetListingViewModel>(navigationService);
            ExitCommand = new ExitCommand();
        }
    }
}

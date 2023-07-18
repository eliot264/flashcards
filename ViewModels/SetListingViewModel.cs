using Flashcards.Commands;
using Flashcards.Data;
using Flashcards.Services;
using Flashcards.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flashcards.ViewModels
{
    public class SetListingViewModel : ViewModelBase
    {
        private readonly DataContextStore _dataContextStore;
        private readonly NavigationStore _navigationStore;
        private readonly ObservableCollection<SetViewModel> _sets;
        public IEnumerable<SetViewModel> Sets => _sets;
        public ICommand GoToMenuViewCommand { get; }
        public ICommand RefreshDataContextCommand { get; }
        public SetListingViewModel(DataContextStore dataContextStore, NavigationStore navigationStore)
        {
            _dataContextStore = dataContextStore;
            _navigationStore = navigationStore;
            _sets = new ObservableCollection<SetViewModel>();

            InitializeSets();

            NavigationService<MenuViewModel> navigationService = new NavigationService<MenuViewModel>(navigationStore, () => new MenuViewModel(navigationStore, _dataContextStore));
            GoToMenuViewCommand = new NavigateCommand<MenuViewModel>(navigationService);
            RefreshDataContextCommand = new RefreshDataContextCommand(this);
        }

        public void RefreshDataContext()
        {
            _dataContextStore.CurrentContext = new FlashcardContext();
            InitializeSets();
        }

        private void InitializeSets()
        {
            _sets.Clear();

            foreach (var set in _dataContextStore.CurrentContext.Sets)
            {
                _sets.Add(new SetViewModel(set, _dataContextStore, _navigationStore));
            }

            OnPropertyChanged(nameof(Sets));
        }
    }
}

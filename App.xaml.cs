using Flashcards.Data;
using Flashcards.Services;
using Flashcards.Stores;
using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DataContextStore _dataContextStore;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _dataContextStore = new DataContextStore(new FlashcardContext());
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new MenuViewModel(_navigationStore, _dataContextStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}

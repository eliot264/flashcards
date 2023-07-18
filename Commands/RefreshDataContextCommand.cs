using Flashcards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    public class RefreshDataContextCommand : CommandBase
    {
        private readonly SetListingViewModel _setListingViewModel;
        public RefreshDataContextCommand(SetListingViewModel setListingViewModel)
        {
            _setListingViewModel = setListingViewModel;
        }
        public override void Execute(object? parameter)
        {
            _setListingViewModel.RefreshDataContext();
        }
    }
}

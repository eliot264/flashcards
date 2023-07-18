using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.Commands
{
    class ExitCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

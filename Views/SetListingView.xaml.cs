using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcards.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SetListingView.xaml
    /// </summary>
    public partial class SetListingView : UserControl
    {
        public SetListingView()
        {
            InitializeComponent();
        }

        private void SetsItemsControl_Loaded(object sender, RoutedEventArgs e)
        {
            IsEmpty();
            SetsItemsControl.LayoutUpdated += SetsItemsControl_LayoutUpdated;
        }

        private void SetsItemsControl_LayoutUpdated(object? sender, EventArgs e)
        {
            IsEmpty();
        }

        private void IsEmpty()
        {
            if(SetsItemsControl.Items.Count == 0)
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorTextBlock.Visibility = Visibility.Hidden;
            }
        }
    }
}

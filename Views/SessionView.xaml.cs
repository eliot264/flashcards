using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcards.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SessionView.xaml
    /// </summary>
    public partial class SessionView : UserControl
    {
        bool isFlipped;
        Duration duration;
        public SessionView()
        {
            isFlipped = false;
            duration = new Duration(TimeSpan.FromSeconds(0.2));
            InitializeComponent();
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            
            double start = isFlipped == true ? -1 : 1;
            double end = isFlipped == true ? 1 : -1;

            DoubleAnimation flipFirstAnimation = new DoubleAnimation(start, 0, duration);

            flipFirstAnimation.Completed += ChangeLabel;

            CardBorder.RenderTransform = new ScaleTransform();

            CardBorder.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, flipFirstAnimation);
            
        }

        private void CheckSide(object sender, RoutedEventArgs e)
        {
            if (isFlipped == true)
            {
                CardBorder.RenderTransform = new ScaleTransform(1, (double)CardBorder.RenderTransform.GetValue(ScaleTransform.ScaleYProperty));
                FrontLabel.Visibility = Visibility.Visible;
                BackLabel.Visibility = Visibility.Hidden;
                isFlipped = !isFlipped;
            }
        }

        private void ChangeLabel(object? o, EventArgs e)
        {
            if(FrontLabel.Visibility == Visibility.Visible)
            {
                FrontLabel.Visibility = Visibility.Hidden;
                BackLabel.Visibility = Visibility.Visible;
            }
            else
            {
                FrontLabel.Visibility = Visibility.Visible;
                BackLabel.Visibility = Visibility.Hidden;
            }

            double end = isFlipped == true ? 1 : -1;

            DoubleAnimation flipSecondAnimation = new DoubleAnimation(0, end, duration);

            CardBorder.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, flipSecondAnimation);

            isFlipped = !isFlipped;
        }
    }
}

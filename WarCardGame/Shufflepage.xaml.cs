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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WarCardGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        

        #region Methods

        //private static void Move(this Image shuffleCard2, double newX, double newY)
        //{
        //    var top = Canvas.GetTop(shuffleCard2);
        //    var left = Canvas.GetLeft(shuffleCard2);
        //    TranslateTransform trans = new TranslateTransform();
        //    shuffleCard2.RenderTransform = trans;
        //    DoubleAnimation anim1 = new DoubleAnimation(top, newY - top, TimeSpan.FromSeconds(10));
        //    DoubleAnimation anim2 = new DoubleAnimation(top, newX - top, TimeSpan.FromSeconds(10));
        //    trans.BeginAnimation(TranslateTransform.XProperty, anim1);
        //    trans.BeginAnimation(TranslateTransform.YProperty, anim2);


        //}



        #endregion

        public GameWindow()
        {
            InitializeComponent();
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {

            //trying to just move the image back and forth
            Canvas.SetLeft(shuffleCard, 1);
            Canvas.SetTop(shuffleCard, 1);


            var gameTable = new gameTable();
            gameTable.Show();
            this.Close();


            //shuffle
            //shuffleCard2.Margin = new Thickness(shuffleCard2.Margin.Right + 100);
            //shuffleCard.Width = 1000;

            //close out of everything

        }
    }
}

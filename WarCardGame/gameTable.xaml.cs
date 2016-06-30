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
using System.Windows.Shapes;

namespace WarCardGame
{
    /// <summary>
    /// Interaction logic for gameTable.xaml
    /// </summary>
    /// 
    public partial class gameTable : Window
    {

        private static Random rand = new Random();

        private static Random random { get { return random; } }

        private int currentCard = 0;


        public gameTable()
        {
            InitializeComponent();
        }

        private void btn_NextCard_Click(object sender, RoutedEventArgs e)
        {

            //need to setup loop to each time the button pushed a new card will show



            Test1.Source = App.WarGame.GetPlayerHand(0)[currentCard].CardImage;
            Test2.Source = App.WarGame.GetPlayerHand(1)[currentCard].CardImage;
            Test3.Source = App.WarGame.GetPlayerHand(2)[currentCard].CardImage;
            Test4.Source = App.WarGame.GetPlayerHand(3)[currentCard].CardImage;
            currentCard++;


            //var p1h = App.WarGame.GetPlayerHand(0);
            // var card = p1h[currentCard];

            var rules1 = new Rules();


            // u will have to get rid of this later
            //currentCard++;

            // Reset deck if index is above # of cards per player
            //if (currentCard >= 52 / 4)
            //game = new WarCard.Game(4);


            //var card = new WarCard(WarCard.Suits.Diamond, WarCard.Cards.C10);
            //TestImage.Source = card.CardImage;
            

        }
    }
}

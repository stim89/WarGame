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
            var hands = new List<List<WarCard>>();
            var players = new List<int>();

            switch (App.WarGame.NumberOfPlayers)
            {
                case 2:
                    if (App.WarGame.Hands[0].Count > 0)
                    {
                        Test1.Source = App.WarGame.Hands[0][currentCard].CardImage;
                        players.Add(0);
                    }
                    else
                    {
                        Test1.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[1].Count > 0)
                    {
                        Test2.Source = App.WarGame.Hands[1][currentCard].CardImage;
                        players.Add(1);
                    }
                    else
                    {
                        Test2.Source = WarCard.Blank.CardImage;
                    }                    

                    break;
                case 3:
                    if (App.WarGame.Hands[0].Count > 0)
                    {
                        Test1.Source = App.WarGame.Hands[0][currentCard].CardImage;
                        players.Add(0);
                    }
                    else
                    {
                        Test1.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[1].Count > 0)
                    {
                        Test2.Source = App.WarGame.Hands[1][currentCard].CardImage;
                        players.Add(1);
                    }
                    else
                    {
                        Test2.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[2].Count > 0)
                    {
                        Test3.Source = App.WarGame.Hands[2][currentCard].CardImage;
                        players.Add(2);
                    }
                    else
                    {
                        Test3.Source = WarCard.Blank.CardImage;
                    }

                    break;
                case 4:
                    if (App.WarGame.Hands[0].Count > 0)
                    {
                        Test1.Source = App.WarGame.Hands[0][currentCard].CardImage;
                        players.Add(0);
                    }
                    else
                    {
                        Test1.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[1].Count > 0)
                    {
                        Test2.Source = App.WarGame.Hands[1][currentCard].CardImage;
                        players.Add(1);
                    }
                    else
                    {
                        Test2.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[2].Count > 0)
                    {
                        Test3.Source = App.WarGame.Hands[2][currentCard].CardImage;
                        players.Add(2);
                    }
                    else
                    {
                        Test3.Source = WarCard.Blank.CardImage;
                    }
                    if (App.WarGame.Hands[3].Count > 0)
                    {
                        Test4.Source = App.WarGame.Hands[3][currentCard].CardImage;
                        players.Add(3);
                    }
                    else
                    {
                        Test4.Source = WarCard.Blank.CardImage;
                    }

                    break;
            }

            foreach (var playerIndex in players)
                hands.Add(App.WarGame.Hands[playerIndex]);

            currentCard++;
            
            var winner = Rules.GetWinner(hands, players);



            //btn_Winner.Visibility = System.Windows.Visibility.Visible;
            //btn_Losser.Visibility = System.Windows.Visibility.Visible;

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

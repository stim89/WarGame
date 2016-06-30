using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WarCardGame
{
    public class WarCard
    {

        //need to make enum with "suits, cards, owners"
        //need to make a contents for the path ways to my images
        //need to make bool to see if the card is playable
        //need to make properties for the get and set "suits, cards, owners, images, playable cards"
        //need to make constrators for "Id, suit, card, image" 
        //need to make method for the bitimage to determent how the suit and card image will be grabbed

        #region ENUM

        public enum Suits { None = -1, Spade = 0, Cub = 1, Heart = 2, Diamond = 3}

        public enum Cards
        {
            Blank = 0,
            Down = 1,
            C2 = 2,
            C3 = 3,
            C4 = 4,
            C5 = 5,
            C6 = 6,
            C7 = 7,
            C8 = 8,
            C9 = 9,
            C10 = 10,
            CJ = 11,
            CQ = 12,
            CK = 13,
            CA = 14,
        }

        public enum Owner { None, Computer, Player}

        #endregion



        #region contents

        private const string Table_Items_Path = @"pack://application:,,,/Images/TableItems/";
        private const string Cards_Path = @"pack://application:,,,/Images/Cards/";

        #endregion


        #region bool playable
        private bool m_playable;

        #endregion



        #region properties

        public Guid Id { get; private set; }
        public Suits CardSuit { get; private set; }
        public Cards Card { get; private set; }
        public BitmapImage CardImage { get; private set; }
        public Owner owner { get;  set; }
        public bool Playable
        {
            get
            {
                if (owner == Owner.None ||
                    CardSuit == Suits.None ||
                    Card == Cards.Blank)
                {
                    return false;
                }
                else
                {
                    return m_playable;
                }
            }
            set
            {
                m_playable = value;
            }
        }

        #endregion



        #region Constructors

        public WarCard(Suits suit, Cards card)
        {
            Id = Guid.NewGuid();
            CardSuit = suit;
            Card = card;
            CardImage = GetCardImage(suit, card);

        }

        #endregion



        #region method

        public BitmapImage GetCardImage(Suits suit, Cards card)
        {

            if (suit == Suits.None)
            {
                if (card == Cards.Blank)
                {
                    return Utilities.GetImage(Table_Items_Path + "Blank.png");
                }
                else if (card == Cards.Down)
                {
                    return Utilities.GetImage(Cards_Path + "Down.png");
                }
                else
                    return null;
            }
            else
            {
                return Utilities.GetImage(Cards_Path + (int)card + suit.ToString() + ".png");
            }

        }

        #endregion

        //game logic
        //keep score
        //play again?

        #region game logic and setup


        #region setup
        bool playAgain;






        #endregion










        #endregion







    }

    public struct Stats
    {
        public int Player1Wins;
        public int ComputerWins;
        public int Player1Loss;
        public int ComputerLoss;
        public int TiesWon;
        public int GamesPlayed;
    }


    public class Deck
    {
        private List<WarCard> deck;
        private int currentCard = 0;
        private Random rand;

        public Deck()
        {
            deck = new List<WarCard>();
            currentCard = 0;

            for (int suit = 0; suit <= 3; suit++)
            {
                for (int rank = 2; rank <= 14; rank++)
                {
                    deck.Add(new WarCard((WarCard.Suits)suit, (WarCard.Cards)rank));
                }
            }
        }

        public WarCard this[int i] { get { return deck[i]; } }

        public int Count { get { return deck.Count; } }

        public void Shuffle()
        {
            rand = new Random(Guid.NewGuid().GetHashCode());

            var dupedDeck = new List<WarCard>();
            dupedDeck.AddRange(deck);

            var count = deck.Count;
            deck = new List<WarCard>();
            while (deck.Count != count)
            {
                var cardIndex = rand.Next(0, count - deck.Count);
                deck.Add(dupedDeck[cardIndex]);
                dupedDeck.RemoveAt(cardIndex);
            }
        }

        public WarCard DealCard()
        {
            if (currentCard < deck.Count)
                return deck[currentCard++];
            else
            {
                return null;
            }
        }
    }

    public class Game
    {
        private Deck deck;
        public int NumberOfPlayers { get; private set; }

        private List<WarCard>[] hands;

        public Game(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            deck = new Deck();
            deck.Shuffle();
            hands = new List<WarCard>[numberOfPlayers];

            var cardsPerPlayer = deck.Count / numberOfPlayers;

            for (int player = 0; player < numberOfPlayers; player++)
            {
                hands[player] = new List<WarCard>();
                for (int card = player * cardsPerPlayer; card < (player + 1) * cardsPerPlayer; card++)
                {
                    hands[player].Add(deck[card]);
                }
            }



        }



        public List<WarCard> GetPlayerHand(int player)
        {
            return hands[player];
        }





    }



    public class Rules
    {
        public List<WarCard> winnerCards { get; set; }
        public List<WarCard> loseCard { get; set; }

        public Rules()

        {
            //make new lists to add them with the players hand
            winnerCards = new List<WarCard>();
            loseCard = new List<WarCard>();


            var cardIndex = 0;
            
            var firstPlayerCurrentCard = App.WarGame.GetPlayerHand(0)[cardIndex];
            var secondPlayerCurrentCard = App.WarGame.GetPlayerHand(1)[cardIndex];
            var thirdPlayerCurrentCard = App.WarGame.GetPlayerHand(2)[cardIndex];
            var fourthPlayerCurrentCard = App.WarGame.GetPlayerHand(3)[cardIndex];


            if (firstPlayerCurrentCard.Card == secondPlayerCurrentCard.Card || firstPlayerCurrentCard.Card == thirdPlayerCurrentCard.Card || firstPlayerCurrentCard.Card == fourthPlayerCurrentCard.Card)
            {
                //setup a loop for == 's because it could happen many times in a row, call the next card from each player than check if they == each other again if not the player with the highest card wins
            }
            else if (firstPlayerCurrentCard.Card > secondPlayerCurrentCard.Card && firstPlayerCurrentCard.Card > thirdPlayerCurrentCard.Card && firstPlayerCurrentCard.Card > fourthPlayerCurrentCard.Card)
            {
                //player 1 wins and keeps all the current cards
                //so return put the won cards in player 1 list...like hands[player].Add(deck[card]);
                //App.WarGame.GetPlayerHand.firstPlayerCurrentCard.add(secondPlayerCurrentCard);

                //temp to add to the cards to the winner from other players cards
                winnerCards.Add(secondPlayerCurrentCard);
                winnerCards.Add(thirdPlayerCurrentCard);
                winnerCards.Add(fourthPlayerCurrentCard);

                //temp to remove the card from the players list
                loseCard.Remove(secondPlayerCurrentCard);
                loseCard.Remove(thirdPlayerCurrentCard);
                loseCard.Remove(fourthPlayerCurrentCard);

                //i guess it is a temp to make sure the new cards where added to the list
                winnerCards = new List<WarCard>();
                loseCard = new List<WarCard>();

                //after this need to make the card go face down and re loop the next card button


            }
            else if (secondPlayerCurrentCard.Card > firstPlayerCurrentCard.Card && secondPlayerCurrentCard.Card > thirdPlayerCurrentCard.Card && secondPlayerCurrentCard.Card > fourthPlayerCurrentCard.Card)
            {
                //player 2 wins and keeps all the current cards
                //so return put the won cards in player 1 list...like hands[player].Add(deck[card]);

                winnerCards.Add(firstPlayerCurrentCard);
                winnerCards.Add(thirdPlayerCurrentCard);
                winnerCards.Add(fourthPlayerCurrentCard);

                loseCard.Remove(firstPlayerCurrentCard);
                loseCard.Remove(thirdPlayerCurrentCard);
                loseCard.Remove(fourthPlayerCurrentCard);

                winnerCards = new List<WarCard>();
                loseCard = new List<WarCard>();
            }
            else if (thirdPlayerCurrentCard.Card > firstPlayerCurrentCard.Card && thirdPlayerCurrentCard.Card > secondPlayerCurrentCard.Card && thirdPlayerCurrentCard.Card > fourthPlayerCurrentCard.Card)
            {
                //player 3 wins and keeps all the current cards
                //so return put the won cards in player 1 list...like hands[player].Add(deck[card]);

                winnerCards.Add(secondPlayerCurrentCard);
                winnerCards.Add(firstPlayerCurrentCard);
                winnerCards.Add(fourthPlayerCurrentCard);

                loseCard.Remove(secondPlayerCurrentCard);
                loseCard.Remove(firstPlayerCurrentCard);
                loseCard.Remove(fourthPlayerCurrentCard);

                winnerCards = new List<WarCard>();
                loseCard = new List<WarCard>();
            }
            else
            {
                //player 4 wins and keeps all the cards
                //so return put the won cards in player 1 list...like hands[player].Add(deck[card]);
                winnerCards.Add(secondPlayerCurrentCard);
                winnerCards.Add(thirdPlayerCurrentCard);
                winnerCards.Add(firstPlayerCurrentCard);

                loseCard.Remove(secondPlayerCurrentCard);
                loseCard.Remove(thirdPlayerCurrentCard);
                loseCard.Remove(firstPlayerCurrentCard);

                winnerCards = new List<WarCard>();
                loseCard = new List<WarCard>();

            }
        }



    }
    //write players remove card and add card list
    public class Order
    {


        bool playedCard = false;


        public Order()
        {


            int playerOrder = 0;

            switch (playerOrder)
            {
                case 0:
                    while ((!playedCard))
                    {
                        playerOrder++;
                        playedCard = true;
                    }
                    break;
                case 1:
                    while ((!playedCard))
                    {
                        playerOrder++;
                        playedCard = true;
                    }
                    break;
                case 2:
                    while ((!playedCard))
                    {
                        playerOrder++;
                        playedCard = true;
                    }
                    break;
                case 3:
                    while ((!playedCard))
                    {
                        playerOrder++;
                        playedCard = true;
                    }
                    break;
                case 4:
                    playerOrder = 0;
                    break;
            }
            if (playedCard == false)
            {
                //call the rules method
                //maybe not right here but in the rules method... playerCard = true;

            }



            #region attmept 1 for the players order
            //for (int playerOrder = 0; playerOrder == 0; playerOrder++)
            //{

            //logic fo the firstplayer to play
            //if (playerOrder == 0)
            //{
            //  logic for frist player to play card
            //if(btn_NextCard == enabled)
            //{
            //  playerOrder++
            //}



            //}


            //if (playerOrder == 1)
            //{
            //logic for second player to play card
            //if(btn_NextCard == enabled)
            //{
            //  playerOrder++
            //}

            //}
            //if (playerOrder == 2)
            //{
            //logic for third player to play card
            //if(btn_NextCard == enabled)
            // {
            //   playerOrder++
            //}
            //}
            //(playerOrder == 3)
            //{
            //logic for third player to play card
            //if(btn_NextCard == enabled)
            //{
            //  playerOrder++
            //}
            //}
            //if(playerOrder == 4)
            //{
            //  logic for third player to play card
            //if(btn_NextCard == enabled)
            //{
            //  playerOrder++
            //}
            //}
            //else
            //{
            //  need to reset the order or you excited the amount of players 
            //  playerOrder = 0;
            //}

            //}




            //i will use this to indcate which player should go next
            //int firstPlayer = 0;
            //int secondPlayer = 1;
            //int thirdPlayer = 2;
            //int fourthPlayer = 3;
            #endregion




        }

    }
}

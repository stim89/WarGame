using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    class warLogic
    {
        #region setup
        public enum Suit
        {
            Diamonds, Spades, Clubs, Hearts
        }
        public enum FaceValue
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }


        public struct Stats
        {
            public int Player1Wins;
            public int Player2Wins;
            public int Player1Loss;
            public int Player2Loss;
            public int TotalBattles;
            public int TotalWars;
        }

        public class Card
        {
            // Members/Fields
            private readonly Suit suit;
            private readonly FaceValue faceVal;
            // Properties
            public Suit Suit { get { return suit; } }
            public FaceValue FaceVal { get { return faceVal; } }
            // Constructor
            public Card(Suit suit, FaceValue faceVal)
            {
                this.suit = suit;
                this.faceVal = faceVal;
            }
            // Override
            public override string ToString()
            {
                return "The " + faceVal.ToString() + " of " + suit.ToString();
            }
        }
        public class Deck
        {
            // Members/Fields
            private string sDeck;
            protected List<Card> cards = new List<Card>();
            private Random random;
            // Properties
            public Card this[int position] { get { return (Card)cards[position]; } }
            public int Cards { get { return cards.Count; } }
            // Constructor
            public Deck()
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    foreach (FaceValue f in Enum.GetValues(typeof(FaceValue)))
                    {
                        cards.Add(new Card(s, f));
                    }
                }
                random = new Random();
            }
            // Public Methods
            public Card Draw()
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            public void Shuffle()
            {
                for (int n = 0; n != 1; n++)
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        int index1 = i;
                        int index2 = random.Next(cards.Count);
                        SwapCard(index1, index2);
                    }
                }
            }
            public void Shuffle(int SuffleAmount)
            {
                if (SuffleAmount == 0)
                {
                    throw new ArgumentException("You must shuffle at least once");
                }
                else
                {
                    for (int n = 0; n != SuffleAmount; n++)
                    {
                        for (int i = 0; i != cards.Count; i++)
                        {
                            int index1 = i;
                            int index2 = random.Next(cards.Count);
                            SwapCard(index1, index2);
                        }
                    }
                }
            }
            // Private Method
            private void SwapCard(int index1, int index2)
            {
                Card card = cards[index1];
                cards[index1] = cards[index2];
                cards[index2] = card;
            }
            // Override
            public override string ToString()
            {
                foreach (Card c in cards)
                {
                    sDeck += string.Format("{0}\n", c);
                }
                return sDeck;
            }
        }
        public class Hand
        {
            // Members/Fields
            protected List<Card> cards = new List<Card>();
            // Properties
            public int NumCards { get { return cards.Count; } }
            public List<Card> Cards { get { return cards; } }
            // Public Method
            public bool ContainsCard(FaceValue item)
            {
                foreach (Card c in cards)
                {
                    if (c.FaceVal == item)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public class Player
        {
            // Members/Fields
            private string sDeck;
            private Deck curDeck;
            private List<Card> cards = new List<Card>();
            private int Win = 0, Loss = 0;
            // Properties
            public Deck CurrentDeck { get { return curDeck; } set { curDeck = value; } }
            public int CardCount { get { return cards.Count; } }
            public int GetWins { get { return Win; } set { Win = value; } }
            public int GetLosses { get { return Loss; } set { Loss = value; } }
            // Public Methods
            public void AddCard(Card c)
            {
                cards.Add(c);
            }
            public Card RemCard()
            {
                Card card = cards[0];
                cards.RemoveAt(0);
                return card;
            }
            // Override
            public override string ToString()
            {
                foreach (Card c in cards)
                {
                    sDeck += string.Format("{0}\n", c);
                }
                return sDeck;
            }
        }
        public class Deal
        {
            // Members/Fields
            private Deck deck = new Deck();
            // Properties
            public Deck GetDeck { get { return deck; } }
            // Public Methods
            public void DealCards(Player p1, Player p2)
            {
                deck.Shuffle(10);
                for (int i = 0; i != 26; i++)
                {
                    p1.AddCard(deck.Draw());
                    p2.AddCard(deck.Draw());
                }
            }
        }
        public class War
        {
            // Members/Fields
            private Player player1 = new Player();
            private Player player2 = new Player();
            private Deal dealCards = new Deal();
            private int BattleCount = 0;
            private int wars = 0;
            private string sStatus = "";
            private Random r = new Random(Environment.TickCount);
            private int rn;
            public int Player1Wins { get { return player1.GetWins; } }
            public int Player1Loss { get { return player1.GetLosses; } }
            public int Player2Wins { get { return player2.GetWins; } }
            public int Player2Loss { get { return player2.GetLosses; } }
            public int Battels { get { return BattleCount; } }
            public int Wars { get { return wars; } }
            // Constructors
            public War()
            {
                dealCards.DealCards(player1, player2); // Start The Game
            }
            // Public Methods
            public void PlayGame()
            {
                while (true)
                {
                    //Console.WriteLine(player1.CardCount + "\n" + player2.CardCount+"\n\n"); // Debug Information
                    Battle(player1, player2); // Battle
                    BattleCount++; // Keep count of the number of battles
                    if (sStatus == "!!! War !!!")
                    {
                        sStatus = WarBattle(player1, player2);
                        wars++;
                    }
                    if (player1.CardCount == 0 || player2.CardCount == 52)
                    {
                        //Console.WriteLine("Player 2 Wins"); // Comented out to compute results faster
                        break;
                    }
                    if (player1.CardCount == 52 || player2.CardCount == 0)
                    {
                        //Console.WriteLine("Player 1 Wins"); // Comented out to compute results faster
                        break;
                    }
                }
            }
            #endregion

            #region battle logic
            public void SingleBattle() 
            {
                Console.Write(Battle(player1, player2));
                Console.WriteLine("\n--- Game Stats ---\nBattle: {0}\nPlayer1 Card Count: {1}|{3}\nPlayer2 Card Count: {2}|{4}", BattleCount + 1, player1.CardCount, player2.CardCount, player1.CardCount - 26, player2.CardCount - 26);
                BattleCount++;
                if (sStatus == "!!! War !!!")
                    sStatus = WarBattle(player1, player2);
            }
            // Private Methods
            private string Battle(Player p1, Player p2)
            {
                // Remove 1 Card from Player1 and player2 Deck
                Card p1Card = p1.RemCard(); 
                Card p2Card = p2.RemCard(); 
                                            
                if (p1Card.FaceVal > p2Card.FaceVal)
                {
                    rn = r.Next(1, 2);
                    if (rn == 1)
                    {
                        p1.AddCard(p1Card);
                        p1.AddCard(p2Card);
                    }
                    if (rn == 2)
                    {
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                    }
                    player1.GetWins++;
                    player2.GetLosses++;
                    return "Player 1 has won!";
                }
                else if (p2Card.FaceVal > p1Card.FaceVal)
                {
                    rn = r.Next(1, 2);
                    if (rn == 1)
                    {
                        p1.AddCard(p1Card);
                        p1.AddCard(p2Card);
                    }
                    if (rn == 2)
                    {
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                    }
                    player1.GetLosses++;
                    player2.GetWins++;
                    return "Player 2 has won!";
                }
                else if (p1Card.FaceVal == p2Card.FaceVal)
                {
                    return "!!! War !!!";
                }
                else
                {
                    return "eRR";
                }
            }


            private string WarBattle(Player p1, Player p2)
            {
                // Burn both player's cards "face down"
                Card p1Burn1 = p1.RemCard(); 
                Card p1Burn2 = p1.RemCard(); 
                Card p2Burn1 = p2.RemCard(); 
                Card p2Burn2 = p2.RemCard();
                //actuall "battle" card                             
                Card p1Card = p1.RemCard();  
                Card p2Card = p2.RemCard(); 
                                            
                if (p1Card.FaceVal > p2Card.FaceVal)
                {
                    rn = r.Next(1, 16);
                    switch (rn)
                    {
                        case 1:
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            break;
                        case 2:
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Burn1);
                            break;
                        case 3:
                            p1.AddCard(p1Card);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            break;
                        case 4:
                            p1.AddCard(p1Card);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            break;
                        case 5:
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p1Card);
                            break;
                        case 6:
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn1);
                            break;
                        case 7:
                            p1.AddCard(p2Card);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            break;
                        case 8:
                            p1.AddCard(p2Card);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            break;
                        case 9:
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            break;
                        case 10:
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Card);
                            break;
                        case 11:
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn2);
                            break;
                        case 12:
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            break;
                        case 13:
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p2Card);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            break;
                        case 14:
                            p1.AddCard(p1Burn1);
                            p1.AddCard(p1Card);
                            p1.AddCard(p1Burn2);
                            p1.AddCard(p2Burn1);
                            p1.AddCard(p2Burn2);
                            p1.AddCard(p2Card);
                            break;
                    }
                    return "Player 1 has won!";
                }
                else if (p2Card.FaceVal > p1Card.FaceVal)
                {
                    rn = r.Next(1, 16);
                    switch (rn)
                    {
                        case 1:
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            break;
                        case 2:
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Burn1);
                            break;
                        case 3:
                            p2.AddCard(p1Card);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            break;
                        case 4:
                            p2.AddCard(p1Card);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            break;
                        case 5:
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p1Card);
                            break;
                        case 6:
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn1);
                            break;
                        case 7:
                            p2.AddCard(p2Card);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            break;
                        case 8:
                            p2.AddCard(p2Card);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            break;
                        case 9:
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            break;
                        case 10:
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Card);
                            break;
                        case 11:
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn2);
                            break;
                        case 12:
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            break;
                        case 13:
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p2Card);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            break;
                        case 14:
                            p2.AddCard(p1Burn1);
                            p2.AddCard(p1Card);
                            p2.AddCard(p1Burn2);
                            p2.AddCard(p2Burn1);
                            p2.AddCard(p2Burn2);
                            p2.AddCard(p2Card);
                            break;
                    }
                    return "Player 2 has won!";
                }
                else if (p1Card.FaceVal == p2Card.FaceVal)
                {
                    return "!!! War !!!";
                }
                else
                {
                    return "ERROR";
                }
            }
        }


        #endregion


        #region ask the player to play again loop and counter for the stats
        class PlayAgain
        {
            static void Main(string[] args)
            {
                // Fields
                War w;
                Stats s = new Stats();
                int NumberOfWarIterations = 1;
                
               // For() Loop to iterate through how ever many you want of new games of wars and to also 
               // keep track of a number of statistics.
                
                for (int i = 0; i != NumberOfWarIterations; i++)
                {
                    w = new War();
                    w.PlayGame();
                    s.Player1Loss += w.Player1Loss;
                    s.Player1Wins += w.Player1Wins;
                    s.Player2Loss += w.Player2Loss;
                    s.Player2Wins += w.Player2Wins;
                    s.TotalBattles += w.Battels; 
                    s.TotalWars += w.Wars;
                }
                // this is how you write it to a console but how to the form??? Display the statistical data
               
                Console.WriteLine("--- Game Stats ---\n");
                Console.WriteLine("Player 1 Wins: {0}", s.Player1Wins);
                Console.WriteLine("Player 1 Loss: {0}\n", s.Player1Loss);
                Console.WriteLine("Player 2 Wins: {0}", s.Player2Wins);
                Console.WriteLine("Player 2 Loss: {0}\n------------------", s.Player2Loss);
                Console.WriteLine("Total Battles: {0}", s.TotalBattles);
                Console.WriteLine(" Total Wars: {0}", s.TotalWars);
                Console.WriteLine("--- End Game Stats ---\n\n");
                
            }

        }

        #endregion
    }
}

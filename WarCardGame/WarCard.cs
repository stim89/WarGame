using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WarCardGame
{
    class WarCard
    {

        //need to make enum with "suits, cards, owners"
        //need to make a contents for the path ways to my images
        //need to make bool to see if the card is playable
        //need to make properties for the get and set "suits, cards, owners, images, playable cards"
        //need to make constrators for "Id, suit, card, image" 
        //need to make method for the bitimage to determent how the suit and card image will be grabbed

        #region ENUM

        public enum Suits { None = -1, Spade = 0, Cub = 1, Hearts = 2, Diamond = 3}

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
            CardImage = GetCardImagePath(suit, card);

        }

        #endregion



        #region method

        private BitmapImage GetCardImagePath(Suits suit, Cards card)
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
                return Utilities.GetImage(Cards_Path + "most of the name for the card" + (int)card + suit.ToString() + ".png");
            }

        }

        #endregion


    }
}

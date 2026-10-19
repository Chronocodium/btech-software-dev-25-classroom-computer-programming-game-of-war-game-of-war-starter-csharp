namespace GameOfWar
{
    public class Card
    {

        // Create a string property Suit with a private setter
        private string _suit = string.Empty; // Appease the Compiler Gods
        public string Suit
        {
            get
            {
                return _suit;
            }
            private set
            {
                _suit = value;
            }
        }

        // Create an int property Rank with a private setter - values should range from 0 for a face value of 2 to 12 for an Ace
        private int _rank;
        public int Rank
        {
            get
            {
                return _rank;
            }
            private set
            {
                if (value >= 0 && value <= 12)
                {
                    _rank = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The rank must be between 0 and 12.");
                }
            }
        }

        // Create a public constructor that takes suit and rank as arguments and assigns them to Suit and Rank
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        // Overload the > operator to compare two cards by rank
        public static bool operator >(Card a, Card b)
        {
            return a.Rank > b.Rank;
        }

        // Overload the < operator to compare two cards by rank
        public static bool operator <(Card a, Card b)
        {
            return a.Rank < b.Rank;
        }

        // Create a public string method RankString that returns a string representation of this card's rank, 2-10 and Jack, Queen, King, Ace
        public string RankString()
        {
            return Deck.RankNames[Rank];
        }
    }
}
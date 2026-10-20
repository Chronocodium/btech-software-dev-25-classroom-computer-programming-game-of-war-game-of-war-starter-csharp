namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        // Create a public int property Count that returns the Count value from the private collection _cards
        public int Count
        {
            get
            {
                return _cards.Count;
            }
        }

        // Create a private field _cards that is a List<Card>
        private List<Card> _cards;

        // Create a public constructor that takes two parameter: a List<card> called cards and a boolean value called isEmptyDeck
        public Deck(List<Card>? cards, bool isEmptyDeck)
        {
            // If cards is not null and has elements in it, assign it to _cards and be done
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
            }
            // If cards is null or empty:
            else
            {
                // _cards should be initialized as an empty List<Card>
                _cards = new List<Card>();
                // InitializeDeck() should be called if and only if isEmptyDeck is false
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }
        }
        
        // Create a private void method called InitializeDeck() which does the following:
        // Use RankNames and Suits in nested loops to generate all 52 combinations of rank and suit and add them to _cards
        private void InitializeDeck()
        {
            foreach (string suit in Suits)
            {
                for (int rank = 0; rank < RankNames.Length; rank++)
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        // Create a public void method called Shuffle() which shuffles (rearranges) the cards in _cards
        public void Shuffle()
        {
            Random range = new Random();

            for (int i = 0; i < _cards.Count; i++)
            {
                int randomIndex = range.Next(_cards.Count);
                Card temp = _cards[randomIndex];

                _cards[randomIndex] = _cards[i];
                _cards[i] = temp;
            }
        }

        // Create a public method CardAtIndex which takes an int parameter for the index of a card
        public Card CardAtIndex(int cardIndex)
        {
            // returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
            if (cardIndex >= 0 && cardIndex < _cards.Count)
            {
                return _cards[cardIndex];
            }
            else
            {
                throw new IndexOutOfRangeException($"Invalid index, please provide an index between 0 and {_cards.Count - 1}.");
            }
        }

        // Create a public method PullCardAtIndex which does exactly the same thing as CardAtIndex with the additional feature that it _removes_ the card from the deck
        public Card PullCardAtIndex(int pullIndex)
        {
            // --Removes-- and returns the card at the index specified, or throws IndexOutOfRangeException if index is too large or too small
            Card pulledCard = CardAtIndex(pullIndex);
            _cards.RemoveAt(pullIndex);
            return pulledCard;
        }

        // Create a public method PullAllCards
        public List<Card> PullAllCards()
        {
            // --Removes-- and returns a list of all of the cards in the deck and removes them all from the deck, leaving it empty
            List<Card> allCards = new List<Card>(_cards);
            _cards.Clear();
            return allCards;
        }

        // Create a public method PushCard that accepts a Card as a parameter and adds it to _cards
        public void PushCard(Card cardToPush)
        {
            _cards.Add(cardToPush);
        }

        // Create a public method PushCards that accepts a List<Card> as a parameter and adds the list to _cards
        // Be sure to use AddRange and not Add
        public void PushCards(List<Card> cardsToPush)
        {
            _cards.AddRange(cardsToPush);
        }

        // Create a public method Deal that accepts an integer representing the number of cards to deal
        public List<Card> Deal(int numberOfCards)
        {
            // and then removes that many cards from the deck, returning them as a List<Card>
            // Be sure to check the size of _cards against the number of cards requested so you don't go out of bounds
            int cardsToDeal;

            if (numberOfCards > _cards.Count)
            {
                cardsToDeal = _cards.Count;
            }
            else
            {
                cardsToDeal = numberOfCards;
            }

            List<Card> cardsDealt = _cards.GetRange(0, cardsToDeal);
            _cards.RemoveRange(0, cardsToDeal);

            return cardsDealt;
        }
    }
}

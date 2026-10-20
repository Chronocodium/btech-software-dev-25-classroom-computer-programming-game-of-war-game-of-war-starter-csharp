using GameOfWar;

// Create an instance of the GameState class
GameState gameState = new GameState();

// Shuffle CardDeck within your instance
gameState.CardDeck.Shuffle();

// Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
gameState.PlayerDeck.PushCards(gameState.CardDeck.Deal(26));
gameState.ComputerDeck.PushCards(gameState.CardDeck.Deal(26));

// Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
static bool PlayCards(GameState state, int playerCardIndex)
{
    // The function should:
    // Pull the card at playerCardIndex from state.PlayerDeck
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);

    // Pull the card at index 0 from state.ComputerDeck
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    // Compare the two cards
    // If the player card is higher, the player gets both cards along with any in state.TableDeck
    if (playerCard > computerCard)
    {
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    // If the computer card is higher, the computer gets both cards along with any in state.TableDeck
    else if (playerCard < computerCard)
    {
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCard(computerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    // If the player and computer cards are the same, both cards go into state.TableDeck
    else
    {
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }

    // Check whether either state.PlayerDeck or state.ComputerDeck are empty
    // If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    // If the player deck is empty, the computer wins and state.Winner should be set to "Player"
    else if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }
    
    // return true
    return true;
}

// Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
Lib.RunGame(gameState, PlayCards);

namespace GameOfWar
{
    public class GameState
    {
        // Create a public Deck property called CardDeck
        public Deck CardDeck{ get; set; }

        // Create a public Deck property called PlayerDeck
        public Deck PlayerDeck{ get; set; }

        // Create a public Deck property called ComputerDeck
        public Deck ComputerDeck{ get; set; }

        // Create a public Deck property called TableDeck
        public Deck TableDeck{ get; set; }

        // Create a public string property called Winner
        public string Winner{ get; set; }

        // Create a public constructor that accepts no parameters. It should:
        public GameState()
        {
            // Initialize Winner to be empty (not null)
            Winner = string.Empty;

            // Initialize CardDeck to be a new, fresh deck of 52 cards
            CardDeck = new Deck(null, false);

            // Initialize PlayerDeck, ComputerDeck, and TableDeck to be empty Deck objects (no cards)
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}
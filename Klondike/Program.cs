//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦

/*Card newCard = new Card();
newCard.faceUp = true;
newCard.value = Value.Queen;
newCard.suit = Suit.Hearts;
string[] renderCard = newCard.Render();
RenderCard(newCard);
*/

CreateGame();

void CreateGame()
{
    Console.WindowHeight    = 3 * ( Card.renderHeight + 1);
    Console.WindowWidth     = 7 * (Card.renderWidth + 1);

    int posX = 0, posY = 0;
    Card[] cards = new Card[51];


    for (int k = 0;k < 3;k++)
    {
        cards[k].faceUp = false;
        cards[k].value = Value.Jack;
        cards[k].suit = Suit.Spades;
    }

    for (int k = 0;k < 3 * 7 - 1;k++)
    {
        if (k == 1 || (k > 7 && k < 15))
        {

        }
        RenderCard(cards[k], k * Card.renderWidth, k * Card.renderHeight);

    }

//  Console.SetCursorPosition(posX, posY);
/*
    Card card = new Card();
    card.faceUp = false;
    card.value = Value.Jack;
    card.suit = Suit.Spades;
    RenderCard(card,posX,posY);

    card.faceUp = true;
    card.value = Value.Ace;
    card.suit = Suit.Spades;
    RenderCard(card, posX + 0 * Card.renderWidth, posY + 1 * Card.renderHeight + 1);

    card.faceUp = true;
    card.value = Value.Three;
    card.suit = Suit.Clubs;
    RenderCard(card, posX + 1 * Card.renderWidth, posY + 1 * Card.renderHeight + 1);

    Console.SetCursorPosition(20, 9);
    card.faceUp = true;
    card.value = Value.Four;
    card.suit = Suit.Hearts;
    RenderCard(card, posX + 2 * Card.renderWidth, posY + 1 * Card.renderHeight+ 1);

    Console.Read();
*/
}

void RenderCard(Card card,int posX, int posY)
{
    for (int i = 0; i < Card.renderHeight + 1; i++)
    {
        Console.SetCursorPosition(posX, posY++);
        Console.WriteLine(card.Render()[i]);
    }
}

enum Suit
{
    Hearts,
    Clubs,
    Spades,
    Diamonds,
}

enum Value
{
    Ace = 01,
    Two = 02,
    Three = 03,
    Four = 04,
    Five = 05,
    Six = 06,
    Seven = 07,
    Eight = 08,
    Nine = 09,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
}

class Card
{
    public Suit suit;
    public Value value;
    public bool faceUp;

    private string[] symbols = { "♠", "♣", "♥", "♦" };

    public const int renderHeight = 7;
    public const int renderWidth = 9;

    public string[] Render()
    {
        if (!faceUp)
        {
            return new string[]
            {
                $"┌───────┐",
                $"|░░░░░░░|",
                $"│▒▒▒▒▒▒▒│",
                $"│▓▓▓▓▓▓▓│",
                $"│▓▓▓▓▓▓▓│",
                $"│▒▒▒▒▒▒▒│",
                $"|░░░░░░░|",
                $"└───────┘",
            };
        }

        string currentCard = (int)value > 10 || (int)value == 01 ? $"{symbols[((int)suit)]}{value.ToString()[0]}" : $"{symbols[((int)suit)]}{((int)value)}";
        string a = currentCard.Length < 3 ? $"{currentCard} " : currentCard;
        string b = currentCard.Length < 3 ? $" {currentCard}" : currentCard;
        return new string[]
        {
                $"┌───────┐",
                $"|{a}    |",
                $"│▀▄▀▄▀▄▀│",
                $"│       │",
                $"│       │",
                $"│▄▀▄▀▄▀▄│",
                $"|    {b}|",
                $"└───────┘",
        };
    }
}
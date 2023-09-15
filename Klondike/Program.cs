//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦
/*
Card newCard = new Card();
newCard.faceUp = true;
newCard.value = Value.Queen;
newCard.suit = Suit.Hearts;
string[] renderCard = newCard.Render();
RenderCard(newCard);
*/

Card meineDamenUndHerren = new Card();
meineDamenUndHerren.faceUp = true;
meineDamenUndHerren.value = Value.Queen;
meineDamenUndHerren.suit = Suit.Diamonds;
RenderCard(meineDamenUndHerren);


void RenderCard(Card card)
{
    for (int i = 0; i < Card.renderHeight + 1; i++)
    {
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
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

using System.ComponentModel.DataAnnotations;

CreateGame();

void CreateGame()
{
    int[] numbers = new int[52];
    for (int i = 0; i < 52; i++)
    {
        numbers[i] = i;
    }

    Random rnd = new Random();
    int[] permutation = numbers.OrderBy(x => rnd.Next()).ToArray();



    Console.WindowHeight    = 3 * ( Card.renderHeight + 5);
    Console.WindowWidth     = 7 * (Card.renderWidth + 2);

    int posX = 0, posY = 0;
    Card[] cards = new Card[52];
    Card[] shuffledCards = new Card[52];

    for (int k = 1;k < 52; k++)
    {
        int i = (k - 1) / 13;

                cards[k-1] = new Card();
                cards[k-1].faceUp = true;
                cards[k-1].value = (k % 13 == 0) ? (Value) 13 : (Value) (k % 13);
                cards[k-1].suit = (Suit) i;

    }
    
    for (int k = 0; k < 52; k++)
    {
        shuffledCards[k] = cards[permutation[k]];
    }
    
    for (int k = 0; k < 21; k++)
    {
        if (k != 1 && k !=2 && !(k > 6 && k < 14))
        {
            RenderCard(shuffledCards[k], (k % 7) * Card.renderWidth, (k / 7) * Card.renderHeight);
        }
        

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
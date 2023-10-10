namespace Klondike;

internal class Card
{
    public Suit suit;
    public Value value;
    public bool faceUp;

    private protected string[] symbols = { "♥", "♣", "♦", "♠" };

    public const int renderHeight = 7;
    public const int renderWidth = 9;

    public Card(Suit suit, Value value, bool faceUp)
    {
        this.suit = suit;
        this.value = value;
        this.faceUp = faceUp;
    }

    public string[] Render()
    {
        if (!faceUp && (int)value > 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
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
        else if (faceUp && (int)value > 0)
        {
            string currentCard = (int)value > 10 || (int)value == 01 ? $"{symbols[((int)suit)]}{value.ToString()[0]}" : $"{symbols[((int)suit)]}{((int)value)}";
            string a = currentCard.Length < 3 ? $"{currentCard} " : currentCard;
            string b = currentCard.Length < 3 ? $" {currentCard}" : currentCard;

            switch ((int)suit)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

            }
            Console.ForegroundColor = ConsoleColor.Black;
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
        else
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            return new string[]
            {
                $"┌───────┐",
                $"|       |",
                $"│       │",
                $"│       │",
                $"│       │",
                $"│       │",
                $"|       |",
                $"└───────┘",
            };
        }
    }
}
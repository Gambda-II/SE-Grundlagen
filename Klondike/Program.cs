﻿//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦

using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;

CreateGame();

void CreateGame()
{

    Console.Clear();

    Console.WindowHeight = 4 * (Card.renderHeight + 5);
    Console.WindowWidth = 7 * (Card.renderWidth + 2);



    //Card[] cards = CreateShuffledCards(CreateCards());
    // this is for testing, uncomment above and delete below
    //Card[] cards = CreateDebugCards(CreateCards());
    //Card[] cards = CreateShuffledCards(CreateCards());
    Card[] cards = CreateWinCards(CreateCards());

    // using this instead of new Card[0]; I'm not even using this?
    Card[] emptyCards = Array.Empty<Card>();
    Card emptyCard = new Card((Suit)0, (Value)0, true);

    Stack[] stacks = CreateStacks(cards);

    RenderStacks(stacks);

    Console.CursorVisible = false;

    bool isPlaying = true;

    while (isPlaying)
    {
        isPlaying = (stacks[8].stackedCards.Count + stacks[9].stackedCards.Count + stacks[10].stackedCards.Count + stacks[11].stackedCards.Count) < 13 * 4; 
        if (!isPlaying)
        {
            Console.Clear();
            Console.WriteLine("You win!");
            Console.ReadKey();
        }

        Console.Clear();
        RenderStacks(stacks);

        MoveCard();
    }



}

void MoveCard()
{
    int pressedKey = Console.ReadKey().KeyChar;

    if (pressedKey == (int)Inputs.Space)
    {

    }
}


void DisplayText(string textToDisplay, int posX = 0, int posY = 4 * Card.renderHeight + 2)
{
    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
    Console.SetCursorPosition(posX, posY);
    Console.WriteLine(textToDisplay);
    Console.BackgroundColor = ConsoleColor.Black;
}

// for testing
// remove when everything works
Card[] CreateDebugCards(Card[] cards)
{
    Card[] cardsDebug = cards;
    cardsDebug[27] = cardsDebug[12];
    cardsDebug[20] = cardsDebug[13];
    cardsDebug[14] = cardsDebug[26];
    cardsDebug[9] = cardsDebug[3];
    cardsDebug[5] = cardsDebug[2];
    cardsDebug[2] = cardsDebug[1];
    return cardsDebug;
}

Card[] CreateWinCards(Card[] cards)
{
    Card[] winCards = new Card[51];
    winCards[0] = cards[0];
    
    winCards[2] = cards[1];
    winCards[1] = cards[2];

    winCards[3] = cards[5];
    winCards[4] = cards[4];
    winCards[5] = cards[3];

    winCards[6] = cards[9];
    winCards[7] = cards[8];
    winCards[8] = cards[7];
    winCards[9] = cards[6];

    winCards[10] = cards[14];
    winCards[11] = cards[13];
    winCards[12] = cards[12];
    winCards[13] = cards[11];
    winCards[14] = cards[10];

    winCards[15] = cards[20];
    winCards[16] = cards[19];
    winCards[17] = cards[18];
    winCards[18] = cards[17];
    winCards[19] = cards[16];
    winCards[20] = cards[15];

    winCards[21] = cards[27];
    winCards[22] = cards[26];
    winCards[23] = cards[25];
    winCards[24] = cards[24];
    winCards[25] = cards[23];
    winCards[26] = cards[22];
    winCards[27] = cards[21];

    for (int k = 28;k < 51;k++)
    {
        winCards[k] = cards[k];
    }

    return winCards;
}
Card[] CreateShuffledCards(Card[] cards)
{
    int[] numbers = new int[52];
    for (int i = 0; i < 52; i++)
    {
        numbers[i] = i;
    }
    Random rnd = new Random();
    int[] permutation = numbers.OrderBy(x => rnd.Next()).ToArray();

    Card[] shuffledCards = new Card[cards.Length];
    for (int k = 0; k < 52; k++)
    {
        shuffledCards[k] = cards[permutation[k]];
    }

    return shuffledCards;
}

Card[] CreateCards()
{
    Card[] cards = new Card[52];

    for (int k = 1; k < 52 + 1; k++)
    {
        int i = (k - 1) / 13;
        cards[k - 1] = new Card((Suit)i, (k % 13 == 0) ? (Value)13 : (Value)(k % 13), true);
    }

    return cards;
}


void DisplayAllCards(Card[] cards, bool showBoard)
{

    if (showBoard)
    {
        for (int k = 0; k < 21; k++)
        {
            //very not nice
            if (k != 1 && k != 2 && !(k > 6 && k < 14))
            {
                RenderCard(cards[k], (k % 7) * Card.renderWidth, (k / 7) * Card.renderHeight);
            }
        }
    }
    else
    {
        for (int k = 0; k < cards.Length; k++)
        {
            //Console.WriteLine("Card {0} " + string.Join(',', cards[k].suit, cards[k].value),k+1);
            RenderCard(cards[k], (k % 7) * Card.renderWidth, (k / 7) * Card.renderHeight);
        }
    }

}

void RenderEmpty(int posX, int posY)
{
    Console.SetCursorPosition(posX, posY);
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;

    string[] emptyField = new string[]
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

    for (int i = 0; i < 7 + 1; i++)
    {
        Console.SetCursorPosition(posX, posY++);
        Console.WriteLine(emptyField[i]);
    }
}
void RenderCard(Card card, int posX, int posY)
{
    for (int i = 0; i < Card.renderHeight + 1; i++)
    {
        Console.SetCursorPosition(posX, posY++);
        Console.WriteLine(card.Render()[i]);
    }
}

void RenderStack(Stack stack)
{
    int posX = 0, posY = 0;
    int factor = (int)stack.position;
    int numberOfCards = stack.numberOfCards;

    if (factor == 0) // || factor > 9)
    {
        posX = 0 * Card.renderWidth;
        posY = 0 * Card.renderHeight;
        RenderCard(stack.GetCard(0), posX, posY + 1);
    }
    else if (factor == -1)
    {
        posX = 1 * Card.renderWidth + 2;
        posY = 0 * Card.renderHeight;
        RenderCard(stack.GetCard(numberOfCards - 1), posX, posY + 1);
    }
    else if (factor > 7)
    {
        posX = stack.positionX;
        posY = stack.positionY;
        RenderCard(stack.GetCard(numberOfCards - 1), posX, posY + 1);
    }
    else
    {
        posX = (factor - 1) * Card.renderWidth + (int)stack.position - 1;
        posY = 2 * Card.renderHeight;
        for (int k = 0; k < numberOfCards; k++)
        {
            RenderCard(stack.GetCard(k), posX, posY + 2 * k);
        }
    }

}

void RenderStacks(Stack[] stacks)
{
    for (int k = 0; k < 8; k++)
    {
        if (stacks.Length > 0)
        {
            if (k < 7)
            {
                
                //DisplayText($"{stacks[k].stackedCards.Count}", stacks[k].positionX, stacks[k].positionY - 1);

                DisplayText($"{k + 1}", stacks[k].positionX + 4, stacks[k].positionY - 2);
            }
            else
            {
                
                //DisplayText($"{stacks[k].stackedCards.Count}",0,0);

                DisplayText("[SPACE]", stacks[k].positionX + 11, stacks[k].positionY - 4);
            }
            RenderStack(stacks[k]);
        }
        else
        {
            RenderEmpty(stacks[k].positionX, stacks[k].positionY);
        }
    }
    
    //DisplayText($"{stacks[12].stackedCards.Count}", 10, 0);

    if (stacks[12].numberOfCards > 0)
    {
        RenderStack(stacks[12]);
    }
    else
    {
        RenderEmpty(10, 1);
    }

    int i = 7;
    for (int k = 30; k < 61; k = k + 10)
    {
        i += 1;
        
        //DisplayText($"{stacks[i].stackedCards.Count}",k,0);

        if (stacks[i].stackedCards.Count > 0)
        {
            RenderStack(stacks[i]);
        }
        else
        {
            RenderEmpty(k, 1);
        }
    }
}

Stack[] CreateStacks(Card[] cards)
{

    int numberOfCards = cards.Length;

    Stack[] stacks = new Stack[13];
    int x = 1, y = 0;
    stacks[0] = new Stack(cards, x, y, 1);
    for (int k = 1; k < 7; k++)
    {
        y += x; x++;
        stacks[k] = new Stack(cards, x, y, k + 1);
    }
    y += x; x = numberOfCards - y;
    stacks[7] = new Stack(cards, x, y, 0); //pool

    stacks[8] = new Stack(cards, 0, 0, 10); //hearts        order
    stacks[9] = new Stack(cards, 0, 0, 20); //spades        might
    stacks[10] = new Stack(cards, 0, 0, 30); //clubs        be
    stacks[11] = new Stack(cards, 0, 0, 40); //diamonds     wrong
    stacks[12] = new Stack(cards, 0, 0, -1); //empty

    return stacks;
}
enum Inputs
{
    Zero = 48,
    One = 49,
    Two = 50,
    Three = 51,
    Four = 52,
    Five = 53,
    Six = 54,
    Seven = 55,
    Eight = 56,
    Nine = 57,
    Space = 32
}

enum Suit
{
    Empty = -1,
    Hearts = 0,
    Clubs = 1,
    Spades = 2,
    Diamonds = 3,
}

enum Value
{
    Empty = -1,
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
enum Position
{
    EmptyStack = -1,
    PoolStack = 0,
    FirstStack = 1,
    SecondStack = 2,
    ThirdStack = 3,
    FourthStack = 4,
    FifthStack = 5,
    SixthStack = 6,
    SeventhStack = 7,
    FinishStackHearts = 10,
    FinishStackClubs = 20,
    FinishStackSpades = 30,
    FinishStackDiamonds = 40
}

class Stack
{
    public List<Card> stackedCards;
    public int numberOfCards;
    public Position position;
    public int positionX, positionY;

    private Card emptyCard = new Card((Suit)0, (Value)0, true);

    public Stack(Card[] cards, int numberOfCards, int firstCardNumber, int position)
    {
        this.numberOfCards = numberOfCards;
        this.position = (Position)position;
        stackedCards = new List<Card>();

        if (position >= 0 && position <= 7)
        {
            positionX = (position - 1) * Card.renderWidth + position - 1;
            positionY = 2 * Card.renderHeight;
        }
        else if (position >= 10)
        {
            positionX = (position / 10 + 1) * Card.renderWidth + 11 + (int)position / 10;
            positionY = 0 * Card.renderHeight;
        }
        else
        {
            positionX = 0;
            positionY = 0;
        }

        for (int i = firstCardNumber; i < firstCardNumber + numberOfCards; i++)
        {
            Card card = cards[i];
            card.faceUp = (i == firstCardNumber + numberOfCards - 1 && position != 0) ? true : false;
            stackedCards.Add(card);

        }

        if (stackedCards.Count() == 0)
        {
        }

    }

    public Card GetCard(int positionOfCard)
    {
        if (stackedCards.Count > 0)
        {
            Card card = stackedCards[positionOfCard];
            return card;
        }
        else
        {
            return emptyCard;
        }

    }

    public void TurnCard(Card card)
    {
        card.faceUp = !(card.faceUp);
    }

    public void AddCard(Card card)
    {
        if (numberOfCards > 0)
        {
            stackedCards.Last<Card>().faceUp = true;
        }

        stackedCards.Add(card);
        stackedCards.Last<Card>().faceUp = true;
        numberOfCards++;
    }

    public void RemoveCard(Card card)
    {

        if (numberOfCards > 0)
        {
            stackedCards.Remove(card);
            numberOfCards--;
            if (numberOfCards == 0)
            {
                // remove this later
            }
            else
            {
                stackedCards.Last<Card>().faceUp = true;
            }

        }
        else if (numberOfCards == 0 && stackedCards.Count > 0)
        {
            stackedCards = new List<Card>();
            stackedCards.Add(emptyCard);

        }

    }
}

class Card
{
    public Suit suit;
    public Value value;
    public bool faceUp;

    private string[] symbols = { "♥", "♣", "♠", "♦" };

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
        if (!faceUp && value > 0)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
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
        else if (faceUp && value > 0)
        {
            string currentCard = (int)value > 10 || (int)value == 01 ? $"{symbols[((int)suit)]}{value.ToString()[0]}" : $"{symbols[((int)suit)]}{((int)value)}";
            string a = currentCard.Length < 3 ? $"{currentCard} " : currentCard;
            string b = currentCard.Length < 3 ? $" {currentCard}" : currentCard;

            switch ((int)suit)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
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

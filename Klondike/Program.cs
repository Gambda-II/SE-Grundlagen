//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦

using System.Linq;


CreateGame();


void CreateGame()
{
    Console.Clear();
    
    Console.WindowHeight = 3 * (Card.renderHeight + 5);
    Console.WindowWidth = 7 * (Card.renderWidth + 2);
    

    int numberOfCards = 52;

    Card[] cards = CreateShuffledCards(CreateCards(numberOfCards));
    Card[] emptyCards = new Card[0];

    Stack[] stacks = CreateStacks(cards);

    /* this should work more easily
    int x = 1, y = 0;
    Stack firstStack = new Stack(cards, x, y, 1);
    RenderStack(firstStack);

    y += x; x++;
    Stack secondStack = new Stack(cards, x, y, 2);
    RenderStack(secondStack);

    y += x; x++;
    Stack thirdStack = new Stack(cards, x, y, 3);
    RenderStack(thirdStack);

    y += x; x++;
    Stack fourthStack = new Stack(cards, x, y, 4);
    RenderStack (fourthStack);

    y += x; x++;
    Stack fifthStack = new Stack(cards, x, y, 5);
    RenderStack(fifthStack);

    y += x; x++;
    Stack sixthStack = new Stack(cards, x, y, 6);
    RenderStack(sixthStack);

    y += x; x++;
    Stack seventhStack = new Stack(cards, x, y, 7);
    RenderStack(seventhStack);

    y += x; x = numberOfCards - y;
    Stack poolStack = new Stack(cards, x, y, 0);
    RenderStack(poolStack);


    Stack heartsStack = new Stack(cards, 0, 0, 10);
    Stack clubsStack = new Stack(cards, 0, 0, 10);
    Stack spadesStack = new Stack(cards, 0, 0, 10);
    Stack diamondsStack = new Stack(cards, 0, 0, 10);
    Stack emptyStack = new Stack(cards, 0, 0, -1);

    */
    RenderStacks(stacks);

    Console.CursorVisible = false;
    //DisplayText("This is some Text");

    

    

}

/*
Stack ChooseStack()
{
    ConsoleKeyInfo pressedKey = Console.ReadKey();
    Stack choosedStack = new Stack(cards, 0, 0, -2); ;
    switch (pressedKey.KeyChar)
    {
        case '1':
            choosedStack = firstStack;
            break;
        case '2':
            choosedStack = secondStack;
            break;
        case '3':
            choosedStack = thirdStack;
            break;
        case '4':
            choosedStack = fourthStack;
            break;
        case '5':
            choosedStack = fifthStack;
            break;
        case '6':
            choosedStack = sixthStack;
            break;
        case '7':
            choosedStack = seventhStack;
            break;
        default:
            DisplayText("Invalid Input");
            break;
    };
    return choosedStack;
}
*/

void MoveCard(Stack startingStack, Stack targetStack)
{
    Card startCard = startingStack.getCard(startingStack.numberOfCards - 1);
    Card targetCard = targetStack.getCard(targetStack.numberOfCards - 1);

    if (CheckValidMove(startCard, targetCard))
    {
        startingStack.RemoveCard(startCard);
        targetStack.AddCard(startCard);
    }
    else
    {
        DisplayText("Can not move cards.");
    }

}

bool CheckValidMove(Card topCard, Card bottomCard)
{
    bool check = false;
    Console.WriteLine((int)topCard.suit == (int)bottomCard.suit);
    Console.WriteLine(topCard.value < bottomCard.value);
    Console.WriteLine(topCard.value);
    Console.WriteLine(bottomCard.value);
    if ((int)topCard.suit == (int)bottomCard.suit & topCard.value < bottomCard.value)
    {
        check = true;
    }

    return check;
}

void DisplayText(string textToDisplay, int posX = 0, int posY = 4 * Card.renderHeight + 2)
{
    Console.SetCursorPosition(posX, posY);
    Console.WriteLine(textToDisplay);
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

Card[] CreateCards(int numberOfCards)
{
    Card[] cards = new Card[numberOfCards];

    for (int k = 1; k < numberOfCards + 1; k++)
    {
        int i = (k - 1) / 13;

        cards[k - 1] = new Card();
        cards[k - 1].faceUp = true;
        cards[k - 1].value = (k % 13 == 0) ? (Value)13 : (Value)(k % 13);
        cards[k - 1].suit = (Suit)i;

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
void RenderCard(Card card,int posX, int posY)
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
        posX = factor * Card.renderWidth;
        posY = 0 * Card.renderHeight;
        RenderCard(stack.getCard(0), posX, posY + 1);
    }
    else
    {

        posX = (factor - 1) * Card.renderWidth + (int)stack.position - 1 ;
        posY = 2 * Card.renderHeight;
        for (int k = 0; k < numberOfCards; k++)
        {
            RenderCard(stack.getCard(k), posX , posY + 1 * k);
        }
    }

}

void RenderStacks(Stack[] stacks)
{
    for (int k = 0; k < 8; k++)
    {
        RenderStack(stacks[k]);
    }

    RenderEmpty(10, 1);
    for (int k = 30; k < 61; k = k + 10)
        RenderEmpty(k, 1);
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
        stacks[k] = new Stack(cards, x, y, k+1);
    }
    y += x; x = numberOfCards - y;
    stacks[7] = new Stack(cards, x, y, 0);
    stacks[8] = new Stack(cards, 0, 0, 10);
    stacks[9] = new Stack(cards, 0, 0, 20);
    stacks[10] = new Stack(cards, 0, 0, 30);
    stacks[11] = new Stack(cards, 0, 0, 40);
    stacks[12] = new Stack(cards, 0, 0, -1);

    return stacks;
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
    public Stack(Card[] cards, int numberOfCards, int firstCardNumber, int position)
    {
        this.numberOfCards = numberOfCards;
        this.position = (Position)position;
        stackedCards = new List<Card>();
        
        for (int i = firstCardNumber; i < firstCardNumber + numberOfCards; i++)
        {
            Card card = cards[i];
            card.faceUp = (i == firstCardNumber + numberOfCards - 1 && position != 0) ? true : false;
            stackedCards.Add(card);
        }

        if (stackedCards.Count() == 0)
        {
            // empty card
            //RenderEmpty() ????
        }

    }

    public List<Card> stackedCards;
    public int numberOfCards;
    public Position position;

    public Card getCard(int positionOfCard)
    {
        Card card = stackedCards[positionOfCard];
        return card;
    }

    public void AddCard(Card card)
    {
        stackedCards.Last<Card>().faceUp = false;
        stackedCards.Add(card);
        
    }

    public void RemoveCard(Card card)
    {
        stackedCards.Remove(card);
        stackedCards.Last<Card>().faceUp = true;
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

    public string[] Render()
    {
        if (!faceUp)
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

}
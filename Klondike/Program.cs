//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦

using System.Linq;

CreateGame();


// moving cards in the bottom works, but needs some testing
// moving cards in the top does not work
// moving a stack of cards does not work
// stack of cards maybe need a MAX VALUE to move
// moving to finishStacks does not work

void CreateGame()
{
    
    Console.Clear();
    
    Console.WindowHeight = 4 * (Card.renderHeight + 5);
    Console.WindowWidth = 7 * (Card.renderWidth + 2);
    

    int numberOfCards = 52;

    Card[] cards = CreateShuffledCards(CreateCards());
    // this is for testing, uncomment above and delete below
    //Card[] cards = CreateDebugCards(CreateCards());

    Card[] emptyCards = Array.Empty<Card>(); // using this instead of new Card[0];

    Stack[] stacks = CreateStacks(cards);

    RenderStacks(stacks);

    Console.CursorVisible = false;
    //DisplayText("This is some Text");

    bool isPlaying = true;

    while (isPlaying)
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        int pressedNumber = (int)pressedKey.KeyChar;
        if (pressedNumber == 48)
        {
            MoveCard(stacks[7], stacks[12],true);
            
        }
        else if (pressedNumber > 48 && pressedNumber < 56)
        {
            
            ConsoleKeyInfo pressedKeyAgain = Console.ReadKey(true);
            int pressedNumberAgain = (int)pressedKeyAgain.KeyChar;
            
            DisplayText($"You want to move from {pressedNumber - 48} to {pressedNumberAgain - 48}");
            Stack firstStackPicked = ChooseStack(stacks, cards,pressedNumber);
            Stack secondStackPicked = ChooseStack(stacks, cards,pressedNumberAgain);
            MoveCard(firstStackPicked,secondStackPicked);
        }

        Console.Clear();
        RenderStacks(stacks);
    }

    

}


Stack ChooseStack(Stack[] stacks, Card[] cards, int input)
{
    // This can be deleted
    //DisplayText("Waiting for input");

    //ConsoleKeyInfo pressedKey = Console.ReadKey(true);
    Stack choosedStack = new Stack(cards, 0, 0, -2); ;
    //int pressedNumber = (int)pressedKey.KeyChar;
    int pressedNumber = input;

    bool invalidInput = true;
    while (invalidInput)
    {
        Console.WriteLine(pressedNumber);
        if (pressedNumber > 48 && pressedNumber < 56)
        {
            choosedStack = stacks[pressedNumber - 49];
            invalidInput = false;
        }
        else if (pressedNumber == 48)
        {
            choosedStack = stacks[pressedNumber +7];
            MoveCard(stacks[pressedNumber - 49 + 7],stacks[pressedNumber - 49 + 12]);
            invalidInput = false;
        }
        else
            DisplayText("Invalid input");
    }

    return choosedStack;
}


void MoveCard(Stack startingStack, Stack targetStack, bool allow = false)
{
    Card startCard = startingStack.GetCard(startingStack.numberOfCards - 1);
    Card targetCard = targetStack.GetCard(targetStack.numberOfCards - 1);

    if (CheckValidMove(startCard, targetCard) || allow)
    {
        startingStack.RemoveCard(startCard);
        targetStack.AddCard(startCard);
    }
    else
    {
        DisplayText($"Can not move cards from {(int)startingStack.position} to {(int)targetStack.position}.");
        
    }

}

bool CheckValidMove(Card topCard, Card bottomCard)
{
    bool check = false;
        if (topCard != null && bottomCard != null)
        {
            if ((int)topCard.suit == (int)bottomCard.suit & topCard.value == bottomCard.value - 1)
            {
                check = true;
            }
        }
        else if (topCard != null && bottomCard == null)
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

// for testing
// remove when everything works
Card[] CreateDebugCards(Card[] cards)
{
    Card[] cardsDebug = cards;
    cardsDebug[27] = cardsDebug[6];
    cardsDebug[20] = cardsDebug[5];
    cardsDebug[14] = cardsDebug[4];
    cardsDebug[9] = cardsDebug[3];
    cardsDebug[5] = cardsDebug[2];
    cardsDebug[2] = cardsDebug[1];
    return cardsDebug;
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
        posX = 0 * Card.renderWidth;
        posY = 0 * Card.renderHeight;
        RenderCard(stack.GetCard(0), posX, posY + 1);
    }
    else if (factor == -1)
    {
        posX = 1 * Card.renderWidth + 2;
        posY = 0 * Card.renderHeight;
        RenderCard(stack.GetCard(0), posX, posY + 1);
    }
    else
    {
        posX = (factor - 1) * Card.renderWidth + (int)stack.position - 1 ;
        posY = 2 * Card.renderHeight;
        for (int k = 0; k < numberOfCards; k++)
        {
            RenderCard(stack.GetCard(k), posX , posY + 2 * k);
        }
    }

}

void RenderStacks(Stack[] stacks)
{
    for (int k = 0; k < 8; k++)
    {
        if (stacks.Length > 0)
            RenderStack(stacks[k]);
        else
            RenderEmpty(stacks[k].positionX, stacks[k].positionY);
    }

    if (stacks[12].numberOfCards > 0)
    {
        RenderStack(stacks[12]);
    }
    else
    {
        RenderEmpty(10, 1);
    }
    
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
    stacks[7] = new Stack(cards, x, y, 0); //pool
    stacks[8] = new Stack(cards, 0, 0, 10); //hearts        order
    stacks[9] = new Stack(cards, 0, 0, 20); //spades        might
    stacks[10] = new Stack(cards, 0, 0, 30); //clubs        be
    stacks[11] = new Stack(cards, 0, 0, 40); //diamonds     wrong
    stacks[12] = new Stack(cards, 0, 0, -1); //empty

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
        
        if (position >= 0)
        {
                positionX = (position - 1) * Card.renderWidth + position - 1;
                positionY = 2 * Card.renderHeight;
        }
        else
        {
            positionX = 0;
            positionY = 0;
        }


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
    public int positionX, positionY;

    public Card emptyCard = new Card();

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

    public void AddCard(Card card)
    {
        if (stackedCards.Count > 0)
        stackedCards.Last<Card>().faceUp = true;

        stackedCards.Add(card);
        stackedCards.Last<Card>().faceUp = true;
        numberOfCards++;
    }

    public void RemoveCard(Card card)
    {
       
        if (stackedCards.Count > 2)
        {
            stackedCards.Remove(card);
            stackedCards.Last<Card>().faceUp = true;
            numberOfCards--;

        }
        else
        {
            stackedCards = new List<Card>();
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
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
    


    //Card[] cards = CreateShuffledCards(CreateCards());
    // this is for testing, uncomment above and delete below
    Card[] cards = CreateDebugCards(CreateCards());

    // using this instead of new Card[0]; I'm not even using this?
    Card[] emptyCards = Array.Empty<Card>();
    Card emptyCard = new Card((Suit)0,(Value)0,true);

    Stack[] stacks = CreateStacks(cards);

    RenderStacks(stacks);

    Console.CursorVisible = false;
    //DisplayText("This is some Text");

    bool isPlaying = true;

    while (isPlaying)
    {
        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
        int pressedNumber = (int)pressedKey.KeyChar;

        // to display the KeyChar number when pressed
        // can be deleted later
        //Console.WriteLine(pressedNumber);
        //Console.ReadLine();


        //one card (bottom one in the display stack) gets lost and replaced (by the top one)
        //number of cards decreases gradually

        switch (pressedNumber)
        {
            case (int)Inputs.Zero:
                
                break;
            case (int)Inputs.Space:
                if (stacks[7].GetCard(0).value > 0)
                {
                MoveCard(stacks[7], stacks[12],true);
                }
                else
                {
                    stacks[7].RemoveCard(stacks[7].GetCard(0));
                    int maxIterations = stacks[12].stackedCards.Count;
                    for (int k = 0;k < maxIterations;k++)
                    {
                        stacks[12].GetCard(0).faceUp = false;
                        MoveCard(stacks[12], stacks[7],true);
                    }
                    stacks[7].GetCard(0).faceUp = false;
                }
                break;
            default:
                break;
                

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
        // this never happens
        // can be removed
        else if (pressedNumber == 32)
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

    Card startCard = startingStack.stackedCards.Count > 0 ? startingStack.GetCard(startingStack.numberOfCards - 1) : startingStack.GetCard(startingStack.stackedCards.Count - 1);
    Card targetCard = targetStack.stackedCards.Count > 0 ? targetStack.GetCard(targetStack.numberOfCards - 1) : targetStack.GetCard(targetStack.stackedCards.Count - 1);

    if (CheckValidMove(startCard, targetCard) || allow)
    {
    
        if (targetCard != null)
        {
            if ((int)targetCard.value < 1)
            {
                targetStack.RemoveCard(targetStack.GetCard(0));
            }
        }

        startingStack.RemoveCard(startCard);

        if (startingStack.numberOfCards < 1)
        {
            startingStack.AddCard(new Card((Suit)0,(Value)0,true));
        }

        targetStack.AddCard(startCard);
        DisplayText($"Moved card {(int)startCard.value} {startCard.suit} from {startingStack.position} to {targetStack.position}",10, 10 + targetStack.numberOfCards);
        DisplayText($"With {startingStack.stackedCards.Count} and {targetStack.stackedCards.Count} number of cards", 30, 10);
    }
    else
    {
        DisplayText($"Can not move cards."); 
    }



    Console.ReadKey();
}

bool CheckValidMove(Card topCard, Card bottomCard)
{
    bool check = false;
        if (topCard != null && bottomCard != null)
        {
            if ((int)topCard.suit == (int)bottomCard.suit & topCard.value == bottomCard.value - 1)
            {
            check = (int)topCard.value < 1 ? false : true;
            }
            else if ((int)bottomCard.value < 1)
            {
            check = ((int)topCard.value == 13 && (int)bottomCard.value < 1) ? true : false;
            }
            else
            {
                check = false;
            }
        }
        else if (topCard != null && bottomCard == null)
        {
        DisplayText("I'm here",0,0);Console.ReadKey();
            check = ((int)topCard.value == 13 && (int)bottomCard.value < 1) ? true : false;
        }
        else
        {
            check = false;
        }

    return check;

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
        cards[k - 1] = new Card((Suit)i, (k % 13 == 0) ? (Value)13 : (Value)(k % 13),true);
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
        RenderCard(stack.GetCard(numberOfCards - 1), posX, posY + 1);        
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
        {
            if(k < 7)
            {
                //DisplayText($"{stacks[k].stackedCards.Count}", stacks[k].positionX, stacks[k].positionY - 1);
                DisplayText($"{k+1}", stacks[k].positionX + 4, stacks[k].positionY - 2);
            } 
            else
            {
                DisplayText("[SPACE]", stacks[k].positionX + 11, stacks[k].positionY - 4);
            }
            RenderStack(stacks[k]);
        }
        else
        {
            RenderEmpty(stacks[k].positionX, stacks[k].positionY);
        }
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

    private Card emptyCard = new Card((Suit)0,(Value)0,true);

    public Stack(Card[] cards, int numberOfCards, int firstCardNumber, int position)
    {
        this.numberOfCards = numberOfCards;
        this.position = (Position)position;
        stackedCards = new List<Card>();

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
        
        for (int i = firstCardNumber; i < firstCardNumber + numberOfCards; i++)
        {
            Card card = cards[i];
            card.faceUp = (i == firstCardNumber + numberOfCards - 1 && position != 0) ? true : false;
            stackedCards.Add(card);

        }

        if (stackedCards.Count() == 0)
        {
            //stackedCards.Add(emptyCard);
            //numberOfCards++;
        }

    }

    public Card GetCard(int positionOfCard)
    {
        if (numberOfCards > 0)
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
                //stackedCards.Add(emptyCard);
                
            }
            else
            {
                stackedCards.Last<Card>().faceUp = true;
            }

        }
        else if (numberOfCards == 0 && stackedCards.Count > 0)
        {
            stackedCards = new List<Card>();
            //stackedCards.Remove(card);
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

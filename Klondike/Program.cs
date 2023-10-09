//Special chracters
//  └ ─ ┘ │ ▀ ▄ ▓ ▒ ░ 
//  ♠ ♣ ♥ ♦


// BUGS
// Can not move a stack of cards if they are the whole stack        FIXED
// Can move wrong cards from empty to bottom                        FIXED
// Sometimes the whole screen turns blue                            I didn't do anything about it, but it never happened again
// Can not move a stack starting with king                          FIXED
// Crashes when trying to move from bottom to empty                 FIXED
// Weird movement happens sometimes, cards get mixed up sometimes   

// NOT INTENDED
// Can undo moves that didnt change anything, snapshots should only be taken, when a legitimate move happened

// TO ADD, TO DO
// How to play: Add Display that shows how to move cards            ADDED
// Can move cards from finish to bottom
// Can undo                                                         ADDED
// Add a Clock / Timer
// Add a score?
// 
// OPTIMIZATION!!!  Only save cards if a valid move happened,
//                  reduce the number of inputs given,
//                  only render changes, not every card,
//                  code gets more messy, add regions / classes
// 
using Klondike;

Stack<Stack[]> gameStateStack = new ();
Card[] karten = CreateCards();
Card[] cards = CreateShuffledCards(karten);
Stack[] stacks = CreateStacks(cards);
TakeSnapshot(stacks);
CreateGame();

void CreateGame()
{

    Console.Clear();

    Console.WindowHeight = 5 * (Card.renderHeight + 3);
    Console.WindowWidth = 6 * (Card.renderWidth + 3);


    // using this instead of new Card[0]; I'm not even using this?
    Card[] emptyCards = Array.Empty<Card>();
    Card emptyCard = new((Suit)(-1), (Value)(-1), true);
    //
    //Stack[] oldStacks = CopyStack(stacks.ToArray());

    RenderStacks(stacks);

    Console.CursorVisible = false;

    bool isPlaying = true, waitingForInput = true, isShowing = true, isGameWon = false;


    while (isPlaying)
    {
        stacks = gameStateStack.ElementAt(gameStateStack.Count - 1);

        ToggleHelpText(isShowing);
        isGameWon = (stacks[8].stackedCards.Count + stacks[9].stackedCards.Count + stacks[10].stackedCards.Count + stacks[11].stackedCards.Count) < 13 * 4;
        if (!isGameWon)
        {
            DisplayWinScreen(karten);
        }

        while (waitingForInput)
        {
            bool isValidInput;
            int firstPressed, secondPressed;
            (isValidInput, firstPressed, secondPressed) = GetInputs();
            waitingForInput = true;

            if (isValidInput)
            {
                int state = GetMovingIndex(firstPressed, secondPressed);

                switch (state)
                {
                    case 0:
                        //Move pool and empty
                        TakeSnapshot(stacks);
                        MoveCardAtTheTop(stacks[7], stacks[12]);
                        break;
                    case 1:
                        //Move empty to finish
                        TakeSnapshot(stacks);
                        MoveCardToFinish(stacks, stacks[12]);
                        break;
                    case 2:
                        //Move empty to bottom
                        TakeSnapshot(stacks);
                        MoveCardToBottom(stacks[12], stacks[secondPressed - 49], firstPressed);
                        break;
                    case 3:
                        //Move bottom to finish
                        TakeSnapshot(stacks);
                        MoveCardToFinish(stacks, stacks[firstPressed - 49]);
                        break;
                    case 4:
                        //Move bottom to bottom
                        TakeSnapshot(stacks);
                        MoveCardToBottom(stacks[firstPressed - 49], stacks[secondPressed - 49], firstPressed);
                        break;
                    case 5:
                        //Move finish to bottom
                        if ((int)secondPressed > 0 && (int)secondPressed < 8)
                        {
                            //TakeSnapshot(stacks);

                        }
                        break;
                    case 6:
                        isShowing = !isShowing;
                        break;
                    case 7:
                        isPlaying = false;
                        DisplayText("PRESS ANOTHER KEY TO CLOSE", 1, 44);
                        break;
                    case 8:
                        //UndoMove();
                        //stacks = CopyStack(oldStacks.ToArray());
                        if (gameStateStack.Count < 2)
                            break;
                        else
                            UndoMove(stacks);
                        break;
                    default:
                        //Dont move
                        break;
                }
                waitingForInput = false;
                //TakeSnapshot(stacks);
            }
        }

        waitingForInput = true;

        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        if (isPlaying)
        {
            RenderStacks(stacks);

        }
        else
        {
            DisplayText("PRESS ANOTHER KEY TO CLOSE", 1, 1);
        }
    }

}

// MoveCards should move one card from one stack to another stack
// MoveCards needs inputs Stack[]
//
// There are 13 stacks
// Top left: pool stack, empty stack
// Bottom: first to seventh stack
// Top right: finish stack for hearts, spades, diamonds, clubs

// pool stack should move to empty stack, if pool stack is not empty else empty stack should move all to pool stack
// case 0
//
// empty stack should move to finish, if card is not empty suit matches and value is one unit bigger e.g. 5Hearts -> 4Hearts
// case 1
// empty stack should move to bottom, if card is not empty suit has different color and value is one unit smaller e.g. 5Hearts -> 6Spades or 6Clubs
// case 2
//
// bottom should move to finish, if card is not empty suit matches and value is one unit bigger e.g. 5Hearts -> 4Hearts
// case 3
// bottom should move to bottom, if card is not empty suit has different color and value is one unit smaller e.g. 5Hearts -> 6Spades or 6Clubs
// case 4
//
// top should move to bottom, if card is not empty and suit has different color and value is one unit smaller e.g. 5Hearts -> 6Spades or 6Clubs
// case 5
//
// else nothing should move
// case 6


void MoveCardAtTheTop(Stack startStack, Stack targetStack)
{
    if (startStack.numberOfCards > 0)
    {
        Card currentCard = startStack.GetLastCard();
        startStack.RemoveCard(currentCard);
        targetStack.AddCard(currentCard);
    }
    else
    {
        // stacks switched here
        // startStack -> targetStack
        // targetStack -> startStack
        while (targetStack.numberOfCards > 0)
        {
            Card currentCard = targetStack.GetLastCard();
            currentCard.faceUp = false;
            targetStack.RemoveCard(currentCard);
            startStack.AddCard(currentCard);
        }
    }
}

void MoveCardToFinish(Stack[] stacks, Stack stackToFinish)
{
    Card currentCard = new(0, 0, false);
    if (stackToFinish.numberOfCards > 0)
    {

        currentCard = stackToFinish.GetLastCard();
    }
    else
    {
        return;
    }

    if (currentCard.value == Value.Ace)
    {
        stackToFinish.RemoveCard(currentCard);
        stacks[8 + (int)currentCard.suit].AddCard(currentCard);
    }
    else if (stacks[8 + (int)currentCard.suit].numberOfCards > 0)
    {
        Card topCard = stacks[8 + (int)currentCard.suit].GetLastCard();
        if (CheckForCorrectValue(topCard, currentCard))
        {
            stackToFinish.RemoveCard(currentCard);
            stacks[8 + (int)currentCard.suit].AddCard(currentCard);
        }
    }
    //    Console.BackgroundColor = ConsoleColor.Black;
}

void MoveCardToBottom(Stack startStack, Stack targetStack, int pressedNumber)
{
    if (startStack.stackedCards.Count < 1)
        return;

    int topValue = (int)startStack.GetLastCard().value;
    if (topValue < 1)
    {
        return;
    }

    if ((int)targetStack.GetLastCard().value < 1 && (int)startStack.GetLastCard().value == 13)
    {
        Card currentCard = startStack.GetLastCard();
        startStack.RemoveCard(currentCard);
        targetStack.RemoveCard(targetStack.GetFirstCard());
        targetStack.AddCard(currentCard);

        return;
    }

    int maxIterations;
    if (pressedNumber == (int)Inputs.Zero)
    {
        maxIterations = IsValidMoveAtBottom(startStack.GetLastCard(), targetStack.GetLastCard()) ? 1 : 0;
    }
    else
    {

        maxIterations = FindIndexForMovingCards(startStack, targetStack);
    }
    int index = startStack.numberOfCards - maxIterations;
    int iterationsStart = 0;

    for (int i = iterationsStart; i < maxIterations; i++)
    {
        Card currentCard = startStack.GetCard(index);
        startStack.RemoveCard(currentCard);
        targetStack.AddCard(currentCard);

    }


}

int FindIndexForMovingCards(Stack startStack, Stack targetStack)
{
    int numberOfCards = startStack.numberOfCards;

    // if there are no cards, dont iterate
    if (numberOfCards < 1)
    {
        return 0;
    }

    // if no cards are facing up, dont iterate
    Card currentCard = startStack.GetLastCard();

    if (!currentCard.faceUp)
    {
        return 0;
    }

    int index = 1;
    Card targetCard = targetStack.GetLastCard();




    while (index <= numberOfCards)
    {
        currentCard = startStack.GetCard(numberOfCards - index);
        // this works, when i switched cards, but why ?
        if (currentCard.faceUp && IsValidMoveAtBottom(currentCard, targetCard))
        {
            return index;
        }

        if (currentCard.faceUp && (int)currentCard.value == 13 && IsValidMoveAtBottom(targetCard, currentCard))
        {
            return index;
        }

        index++;
    }

    return 0;
}


//maybe missing edge cases
bool IsSameSuit(Card firstCard, Card secondCard)
{
    if (firstCard.value == secondCard.value)
    {
        return true;
    }

    return false;
}

bool IsSameSuitColor(Card firstCard, Card secondCard)
{
    if ((int)firstCard.value > 0 && (int)secondCard.value > 0)
    {
        return (int)firstCard.suit % 2 == (int)secondCard.suit % 2;
    }

    return false;
}

bool CheckForCorrectValue(Card bottomCard, Card topCard)
{
    return bottomCard.value == topCard.value - 1;
}

bool IsValidMoveAtBottom(Card bottomCard, Card topCard)
{
    if ((int)bottomCard.value < 1 && (int)topCard.value == 13)
    {
        return true;
    }

    return (!IsSameSuitColor(bottomCard, topCard) && CheckForCorrectValue(bottomCard, topCard));
}

(bool, int, int) GetInputs()
{
    int firstKeyPressed = Console.ReadKey(true).KeyChar;

    if (firstKeyPressed == (int)Inputs.Space)
    {
        return (true, firstKeyPressed, firstKeyPressed);
    }

    if (firstKeyPressed == (int)Inputs.H || firstKeyPressed == 104)
    {
        return (true, 69, 42);
    }

    if (firstKeyPressed == (int)Inputs.ESC)
    {
        return (true, firstKeyPressed, firstKeyPressed);
    }

    if (firstKeyPressed == (int)Inputs.Backspace)
    {
        return (true, firstKeyPressed, firstKeyPressed);
    }

    if (firstKeyPressed >= (int)Inputs.Zero && firstKeyPressed <= (int)Inputs.Seven)
    {
        int secondKeyPressed = Console.ReadKey(true).KeyChar;

        if (secondKeyPressed >= (int)Inputs.Zero && secondKeyPressed <= (int)Inputs.Seven)
        {
            return (true, firstKeyPressed, secondKeyPressed);
        }
        return (false, firstKeyPressed, -100);

    }

    return (false, -100, -100);
}

int GetMovingIndex(int firstValue, int secondValue)
{
    if (firstValue == (int)Inputs.Space)
    {
        return 0;
    }

    if (firstValue == 69)
    {
        return 6;
    }

    if (firstValue == (int)Inputs.ESC)
    {
        return 7;
    }

    if (firstValue == (int)Inputs.Backspace)
    {
        return 8;
    }

    if (firstValue == (int)Inputs.Zero && firstValue == secondValue)
    {
        return 1;
    }
    else if (firstValue == (int)Inputs.Zero && firstValue != secondValue)
    {
        return 2;
    }

    if (firstValue == secondValue)
    {
        return 3;
    }
    else if (firstValue > (int)Inputs.Zero && firstValue < (int)Inputs.Eight && secondValue > (int)Inputs.Zero && secondValue < (int)Inputs.Eight)
    {
        return 4;
    }

    return 5;
}

void DisplayText(string textToDisplay, int posX = 0, int posY = 4 * Card.renderHeight + 2)
{
    Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
    Console.SetCursorPosition(posX, posY);
    Console.WriteLine(textToDisplay);
    Console.BackgroundColor = ConsoleColor.Black;
}

void DisplayWinScreen(Card[] karten)
{
    Console.Clear();
    for (int k = 0; k < 500; k++)
    {
        Array colors = Enum.GetValues(typeof(ConsoleColor));
        Random randomNumber = new();
        ConsoleColor randomColor = (ConsoleColor)colors.GetValue(randomNumber.Next(colors.Length));
        Console.BackgroundColor = randomColor;
        Console.Write("You win! ");
        System.Threading.Thread.Sleep(1);
    }
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    DisplayAllCards(karten, false);
    Console.ReadKey();
}

Card[] CreateShuffledCards(Card[] cards)
{
    int[] numbers = new int[52];
    for (int i = 0; i < 52; i++)
    {
        numbers[i] = i;
    }
    Random rnd = new();
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
            // not 1 and not 2 and not 7 8 9 10 11 12 13
            // is -0 3 4 5 6 14+
            if (k != 1 && k != 2 && !(k > 6 && k < 14))
            {
                RenderCard(cards[k], (k % 7) * Card.renderWidth, (k / 7) * Card.renderHeight);
            }
        }
    }
    else
    {
        int n = 51;
        int[] array = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            array[i] = i;
        }


        Random random = new();
        n = array.Length;
        while (n > 1)
        {
            n--;
            int i = random.Next(n + 1);
            int temp = array[i];
            array[i] = array[n];
            array[n] = temp;
        }


        for (int m = 0; m < cards.Length; m++)
        {
            int k = array[m];
            cards[k].faceUp = true;
            System.Threading.Thread.Sleep(50);
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
        stack.GetCard(stack.stackedCards.Count - 1).faceUp = stack.stackedCards.Count - 1 <= 0;
        RenderCard(stack.GetCard(stack.stackedCards.Count - 1), posX, posY + 1);
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

                //DisplayText($"C:{stacks[k].stackedCards.Count} N:{stacks[k].numberOfCards}", stacks[k].positionX, stacks[k].positionY - 1);

                DisplayText($"{k + 1}", stacks[k].positionX + 4, stacks[k].positionY - 2);
            }
            else
            {

                //DisplayText($"C:{stacks[k].stackedCards.Count} N:{stacks[k].numberOfCards}", 0, 0);

                DisplayText("[SPACE]", stacks[k].positionX + 11, stacks[k].positionY - 4);
            }
            RenderStack(stacks[k]);
        }
        else
        {
            RenderEmpty(stacks[k].positionX, stacks[k].positionY);
        }
    }

    //DisplayText($"C:{stacks[12].stackedCards.Count} N:{stacks[12].numberOfCards}", 10, 0);

    if (stacks[12].numberOfCards > 0)
    {
        RenderStack(stacks[12]);
    }
    else
    {
        RenderEmpty(10, 1);
    }

    int i = 7;
    for (int k = 30; k < 61; k += 10)
    {
        i += 1;

        //DisplayText($"C:{stacks[i].stackedCards.Count} N:{stacks[i].numberOfCards}", k, 0);

        if (stacks[i].stackedCards.Count > 0)
        {
            RenderStack(stacks[i]);
        }
        else
        {
            RenderEmpty(k, 1);
        }
    }
    DisplayText("0", 14, 10);

}

void ToggleHelpText(bool isShowing)
{
    if (isShowing)
    {

        DisplayText("CONTROLS", 1, 43);
        DisplayText("Choose a number (0,1,...,7) from where you want to move,", 1, 44);
        DisplayText("then another number (1,2,...,7) to where you want to move.", 1, 45);
        DisplayText("Press SPACE to get another card", 1, 46);
        DisplayText("Press the same number twice to finish a card", 1, 47);
        DisplayText("Press RETURN <- to undo", 1, 48);
        DisplayText("Press ESC to quit", 1, 49);
        return;
    }
    else
        DisplayText("Press H to show CONTROLS", 1, 44);
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

Stack CopyStack(Stack original)
{
    Stack copy = new(cards, original.numberOfCards, original.firstCardNumber, (int)original.position);

    // Create deep copies of cards in the stack
    List<Card> copiedCards = new();
    foreach (Card card in original.stackedCards)
    {
        copiedCards.Add(new Card(card.suit, card.value, card.faceUp));
    }
    copy.stackedCards = copiedCards;

    return copy;
}




// Function to take a snapshot of the game state and push it onto the stack
void TakeSnapshot(Stack[] stacks)
{
    Stack[] snapshot = new Stack[stacks.Length];

    for (int i = 0; i < stacks.Length; i++)
    {
        // Create a deep copy of each stack and its cards
        snapshot[i] = CopyStack(stacks[i]);
    }

    gameStateStack.Push(snapshot);
}


// Function to undo the last move
void UndoMove(Stack[] stacks)
{
    if (gameStateStack.Count > 0)
    {
        // Pop the last snapshot from the stack
        Stack[] snapshot = gameStateStack.Pop();

        // Restore the game state to the snapshot
        Array.Copy(snapshot, stacks, snapshot.Length);
    }
}
#region enumerates
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
    Space = 32,
    H = 72,
    ESC = 27,
    Backspace = 8

}
enum Suit
{
    Empty = -1,
    Hearts = 0,
    Clubs = 1,
    Diamonds = 2,
    Spades = 3
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
#endregion
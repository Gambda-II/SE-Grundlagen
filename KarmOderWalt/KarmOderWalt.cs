namespace KarmOderWalt;

public class KarmOderWalt
{
    const int easyMin = 1, easyMax = 100, hardMin = 1, hardMax = 1000;

    static int minValue, maxValue;

    int gameState = 0;

    static List<float> scores = new List<float>();
    static List<string> players = new List<string>();

    List<int> guesses = new();
    public KarmOderWalt(int state)
    {
        gameState = state;
        if (gameState == 1)
        {
            minValue = easyMin;
            maxValue = easyMax;
            return;
        }
        if (gameState == 2)
        {
            minValue = hardMin;
            maxValue = hardMax;
            return;
        }
    }

    public static void Main()
    {
        // Reset custom colors
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;


        Intro();
        KarmOderWalt game = new KarmOderWalt(SelectDifficulty());
        RunGame(minValue, maxValue, game.guesses);
        RetryGame();
    }

    private static void RetryGame()
    {
        DisplayMessage("Retry: Yes or No?\nOr Type 'Score' to show the Leaderboard.\n", ConsoleColor.Magenta);
        GetUserInputRetry();
    }

    // >CHANGE< this is kinda messy, change this later
    private static void GetUserInputRetry()
    {
        bool looping = true;
        string userInput = string.Empty;
        while (looping)
        {
            userInput = Console.ReadLine();
            if (userInput == null)
                continue;
            if (userInput.StartsWith("Y") || userInput.StartsWith("y"))
            {
                Console.Clear();
                Main();
                looping = false;
                break;
            }

            if (userInput.StartsWith("N") || userInput.StartsWith("n"))
            {
                DisplayMessage("Thank you for playing 'Karm oder Walt'");
                looping = false;
                break;
            }
            if (userInput.StartsWith("S") || userInput.StartsWith("s"))
            {
                Leaderboard();
                RetryGame();
                looping = false;
                break;
            }
            else
            {
                DisplayMessage("I don't understand.");
            }
        }
    }

    private static void Leaderboard()
    {
        Console.Clear();
        Random rnd = new Random();
        // Black = 1, ..., White = 15
        int colorValue;
        string title = "Username \t \t Score \t \t \n--------+----+----+-----+----+----+\n";
        for (int i = 0; i < title.Length; i++)
        {
            colorValue = rnd.Next(1, 16);
            DisplayMessageWrite($"{title[i]}", (ConsoleColor)colorValue);

        }
        for (int i = 0; i < players.Count; i++)
        {
            string nameToDisplay = players[i].Substring(0, (int)MathF.Min(players[i].Length, 10)).PadRight(10);

            DisplayMessage($"{nameToDisplay} \t \t {scores[i]}");
        }

    }

    private static int SelectDifficulty()
    {
        DisplayMessage($"Please choose a difficulty.\nEasy: Numbers range from {easyMin} to {easyMax}.\nHard: Numbers range from {hardMin} to {hardMax}.\n");
        int gameState = GetUserInputDifficulty();
        return gameState != 0 ? gameState : SelectDifficulty();
    }

    private static int GetUserInputDifficulty()
    {
        string userInputText;
        do
        {
            userInputText = Console.ReadLine();
        }
        while (userInputText == null);

        if (userInputText.StartsWith("E") || userInputText.StartsWith("e"))
        {
            DisplayMessage($"You picked 'Easy mode'.\nPlease enter a number between {easyMin} and {easyMax}.\n", ConsoleColor.Blue);
            return 1;
        }
        if (userInputText.StartsWith("H") || userInputText.StartsWith("h"))
        {
            DisplayMessage($"You picked 'Hard mode'.\nPlease enter a number between {hardMin} and {hardMax}.\n", ConsoleColor.Blue);
            return 2;
        }
        // Not needed anymore, remove this later
        /*
        if (userInputText.StartsWith("R") || userInputText.StartsWith("r"))
        {
            DisplayMessage($"You picked 'Really Hard mode'.\nPlease enter a number between {hardMin} and {hardMax}.\n", ConsoleColor.Blue);
            return 3;
        }
        */
        DisplayMessage($"You typed '{userInputText}':");
        DisplayMessage("Please only type the mode name.\n\n", ConsoleColor.Red);
        return 0;
    }

    private static void Intro()
    {
        DisplayMessage("Hello and welcome to 'Karm oder Walt' where you have to guess a Number.\n");
    }

    private static void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    private static void DisplayMessage(string message, ConsoleColor colorFG = ConsoleColor.White)
    {
        Console.ForegroundColor = colorFG;

        Console.WriteLine(message);

        // Reset the colors in case we're not using default values
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void DisplayMessage(string message, ConsoleColor colorFG = ConsoleColor.White, ConsoleColor colorBG = ConsoleColor.Black)
    {
        Console.BackgroundColor = colorBG;
        Console.ForegroundColor = colorFG;

        Console.WriteLine(message);

        // Reset the colors in case we're not using default values
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void DisplayMessageWrite(string message, ConsoleColor colorFG = ConsoleColor.White)
    {
        Console.ForegroundColor = colorFG;

        Console.Write(message);

        // Reset the colors in case we're not using default values
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }
    private static void RunGame(int min, int max, List<int> guesses)
    {
        int numberToGuess = GenerateNumber(min, max);
        int initGuess = GetUserGuess();
        guesses.Add(initGuess);
        Playing(guesses, numberToGuess);
        GameOverScreen(guesses);
    }

    private static void GameOverScreen(List<int> guesses)
    {

        foreach (int i in guesses)
        {
            DisplayMessage($"You tried the number:\t{i}", ConsoleColor.DarkYellow);
        }
        string triesString = (guesses.Count == 1) ? "try" : "tries";
        DisplayMessage($"\nYou needed {guesses.Count} {triesString}\n");

        // >CHANGE<
        // I'm too lazy to figure the estimated number / expected number of trials, so this has to kinda work
        // Maybe Clamp or Check for the Min Value, so we don't get any negative scores when switching from exponential decline
        // Looks messy anyway, not that anyone will read this anyway
        scores.Add(MathF.Round(100 * maxValue * MathF.Exp(-0.01f * (guesses.Count - 1)), 0));

        DisplayMessage($"Your score is {scores[scores.Count - 1]}");
        DisplayMessage($"Type your name:\n");
        players.Add(Console.ReadLine());


    }

    private static void Playing(List<int> guesses, int numberToGuess)
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            isPlaying = CheckGuess(guesses, numberToGuess);
            if (isPlaying)
                guesses.Add(GetUserGuess());
        }

    }

    private static bool CheckGuess(List<int> guesses, int numberToGuess)
    {
        int index = guesses.Count - 1;
        int currentGuess = guesses[index];

        if (currentGuess < minValue || currentGuess > maxValue)
        {
            DisplayMessage($"Whoopsie doodle! My dear you picked {currentGuess} and that's not in the range I was looking for!! Try again.", ConsoleColor.Red);
            return true;
        }

        if (index == 0)
        {
            if (currentGuess != numberToGuess)
            {
                DisplayMessage($"Your guess was {currentGuess}, but not the number I was looking for. Try another one.", ConsoleColor.DarkYellow);
                return true;
            }
            DisplayMessage($"Your guess was {currentGuess}, the number I was looking for. That was lucky.", ConsoleColor.Green);
            return false;
        }

        int previousGuess = guesses[index - 1];
        return GetKarmWaltMessage(currentGuess, previousGuess, numberToGuess);
    }

    private static bool GetKarmWaltMessage(int currentGuess, int previousGuess, int numberToGuess)
    {
        if (currentGuess == numberToGuess)
        {
            DisplayMessage("Good game. You guessed the number I was looking for.", ConsoleColor.Green);
            return false;
        }

        if (MathF.Abs(numberToGuess - previousGuess) > MathF.Abs(numberToGuess - currentGuess))
        {
            DisplayMessage("Nice! Your new Guess is 'kärmer'.", ConsoleColor.Blue);
            return true;
        }

        DisplayMessage("Oh no! Your new guess is 'wälter'.", ConsoleColor.Red);
        return true;
    }

    private static int GetUserGuess()
    {
        int inputNumber;
        bool wrongFormat;
        do
        {
            wrongFormat = !int.TryParse(Console.ReadLine(), out inputNumber);
            if (wrongFormat)
                DisplayMessage($"I might be wrong, but that is not a number or in the wrong format. Would you kindly just type a decimal number?", ConsoleColor.Red);
        }
        while (wrongFormat);
        return inputNumber;
    }

    private static int GenerateNumber(int minValue, int maxValue)
    {
        Random random = new Random();
        return random.Next(minValue, maxValue + 1);
    }
}
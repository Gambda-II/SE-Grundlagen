// ░▒▓╔╗╚╝║═

using System.Diagnostics;

//to add:
// letters used
// backspace to remove a letter
// only highlight yellow when amount fits
// check if input word is a word

List<string> words = new List<string>();

using (var reader = new StreamReader(@"A:\\Softwareentwicklung\\SE-Grundlagen\\Wörtel\\Wörters\\valid_solutions.csv"))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        words.Add(line);
    }
}

int posX = 0;
int posY = 0;

int trials = 0;
int hits = 0;


string solutionWord = PickSolution();

/*
Thread soundtrack = new Thread(new ThreadStart(PlayMusic));
soundtrack.IsBackground = true;
soundtrack.Start();
*/

while (trials < 6)
{

    Console.CursorVisible = false;
    //Console.SetCursorPosition(30, 10);
    //Console.Write("Letters used");

    TakeAGuess(posX, posY);
    posY += 4;
    trials++;
    if (trials == 6)
    {
        DisplaySolution();
        AskPlayAgain();
        Console.ReadLine();
    }
}

(bool, char) IsALetter(ConsoleKeyInfo key)
{
    // ConsoleKey.A; 65
    // ConsoleKey.Z; 90
    return ((int)key.Key >= 65 && (int)key.Key <= 90, key.KeyChar);

}

void TakeAGuess(int posX, int posY)
{
    char[] guess = new char[5];
    int givenInputs = 0;
    //eigentlich will ich nur weiter gehen, wenn ich enter drücke

    do
    {
        DrawInputField();

        for (int i = 0; i < 5; i++)
        {
            bool isALetter = false;
            while (!isALetter)
            {
                (isALetter, guess[i]) = IsALetter(Console.ReadKey(true));
            }
            givenInputs++;

            RenderSquare(guess[i], 0 + i * 5, 0, ConsoleColor.DarkGray);
        }

        if (Console.ReadKey(true).Key == ConsoleKey.Enter && givenInputs == 4)
        {
            break;
        }

    } while (givenInputs < 5);

    ConsoleColor color = new();
    for (int i = 0; i < 5; i++)
    {
        string currentGuessLetter = guess[i].ToString();
        currentGuessLetter = currentGuessLetter.ToUpper();
        string currentSolutionLetter = solutionWord[i].ToString();

        if (currentGuessLetter == currentSolutionLetter)
        {
            color = ConsoleColor.Green;
            hits++;

        }
        else if (solutionWord.Contains(currentGuessLetter))
        {
            color = ConsoleColor.DarkYellow;
        }
        else
        {
            color = ConsoleColor.White;
        }
        RenderSquare(guess[i], posX + i * 5, posY + 5, color);
    }

    if (hits == 5)
    {
        AskPlayAgain();
        Console.ReadLine();
    }
    hits = 0;
    DrawInputField();
}

void DisplaySolution()
{
    for (int i = 0;i<solutionWord.Length;i++)
    {
        RenderSquare(solutionWord[i],30+i*5,25,ConsoleColor.Red);
    }
}
void AskPlayAgain()
{
    Random r = new Random();
    int i = r.Next(1, 16);

    RenderSquare('P', 30, 1, (ConsoleColor)i);
    RenderSquare('L', 35, 1, (ConsoleColor)i);
    RenderSquare('A', 40, 1, (ConsoleColor)i);
    RenderSquare('Y', 45, 1, (ConsoleColor)i);

    RenderSquare('A', 52, 2, (ConsoleColor)i);
    RenderSquare('G', 57, 2, (ConsoleColor)i);
    RenderSquare('A', 62, 2, (ConsoleColor)i);
    RenderSquare('I', 67, 2, (ConsoleColor)i);
    RenderSquare('N', 72, 2, (ConsoleColor)i);
    RenderSquare('?',77, 2, (ConsoleColor)i);
}

void PlayMusic()
{
    Notes[] notes =

        {
        Notes.B4, Notes.B4, Notes.B4, Notes.B4,
        Notes.B4,
        Notes.B4, Notes.B4, Notes.B4, Notes.B4, Notes.B4, Notes.B4,
        Notes.B4,
        Notes.E5, Notes.E5, Notes.E5, Notes.E5, Notes.E5, Notes.E5,
        Notes.E5,
        Notes.D5, Notes.D5, Notes.D5, Notes.D5, Notes.D5, Notes.D5,
        Notes.D5,
        Notes.A4, Notes.A4
        };
    int[] durs =
    {
        8,8,8,8,
        4,
        8,8,8,8,8,8,
        4,
        8,8,8,8,8,8,
        4,
        8,8,8,8,8,8,
        4,
        8,8
    };
    while (true)
    {

        for (int i = 0; i < notes.Length; i++)
        {
            int freq = ConvertNoteToFrequency(notes[i]);
            // 113bpm -> 1/4 = 531ms
            int dur = 900 / durs[i];
            Console.Beep(freq, dur);
        }
    }
}

int ConvertNoteToFrequency(Notes note)
{
    return (int)note;
}
string PickSolution()
{
    Random random = new Random();
    int index = random.Next(0, words.Count);
    string solution = words[index];
    return solution.ToUpper();
}

void DrawInputField()
{
    for (int i = 0; i < 5; i++)
    {
        RenderSquare(' ', 0 + i * 5, 0, ConsoleColor.DarkGray);
    }
}

void RenderSquare(char x, int posX, int posY, ConsoleColor color)
{
    /*
    string[] square =
    {
        $"▓▓▓▓▓",
        $"▓ {x} ▓",
        $"▓▓▓▓▓"
    };
    */

    string[] square =
    {
        $"╔═══╗",
        $"║ {x} ║",
        $"╚═══╝"
    };

    for (int i = 0; i < square.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(posX, posY + i);
        Console.BackgroundColor = color;
        Console.WriteLine(square[i]);
    }
}

enum Notes
{
    Ksch = 50,
    C3 = 130, // 130.81
    Db3 = 138, // 138.59
    D3 = 146, // 146.83
    Eb3 = 155, // 155.56
    E3 = 164, // 164.81
    F3 = 174, // 174.61
    Gb3 = 185, // 185.00
    G3 = 196, // 196.00
    Ab3 = 207, // 207.65
    A3 = 220, // 220.00
    Bb3 = 233, // 233.08
    B3 = 246, // 246.94
    C4 = 261, // 261.63
    Db4 = 277, // 277.18
    D4 = 293, // 293.66
    Eb4 = 311, // 311.13
    E4 = 329, // 329.63
    F4 = 349, // 349.23
    Gb4 = 369, // 369.99
    G4 = 392, // 392.00
    Ab4 = 415, // 415.30
    A4 = 440, // 440.00
    Bb4 = 466, // 466.16
    B4 = 493, // 493.88
    C5 = 523, // 523.25
    Db5 = 554, // 554.37
    D5 = 587, // 587.33
    Eb5 = 622, // 622.25
    E5 = 659, // 659.25
    F5 = 698, // 698.46
    Gb5 = 739, // 739.99
    G5 = 783, // 783.99
    Ab5 = 830, // 830.61
    A5 = 880, // 880.00
    Bb5 = 932, // 932.33
    B5 = 987, // 987.77
}
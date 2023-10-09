namespace Übungen;
internal class Program
{
    static void Main(string[] args)
    {
        #region data
        List<double[]> rawData = new();
        List<double[]> normalizedData = new();

        for (int i = 0; i < 4; i++)
        {
            Random rand = new Random();
            int n = rand.Next(0, 50);
            /* 
             * with non normalized data values the visuals don't make any sense, ignore a and b for now 
             */
            int a = rand.Next(0, 5);
            int b = rand.Next(a, a + 5);

            a = 0;
            b = 1;

            rawData.Add(ProblemeInMethodenAufteilen.CreateFakeRandomData(n, a, b));

            //below does not work
            normalizedData.Add(ProblemeInMethodenAufteilen.NormalizeData(rawData[i]));
        }
        ProblemeInMethodenAufteilen.CreateVisuals(rawData);
        #endregion

        AskToContinue();

        #region hamming distance
        // the hamming distance of two strings the same length is the number of different characters
        // hamming and jamming => dist = 1
        // hamming and dancing => dist = 3
        // bread and broad => dist = 1
        Console.WriteLine("Let's get the hamming distance of two words of the same length. Input two words...\n");

        HammingDistance.AskForTwoWords(true);

        Console.WriteLine("Now let's get the hamming distance of two words with different lengths. Input two words...\n");

        HammingDistance.AskForTwoWords(false);

        #endregion

        AskToContinue();

        //Console.WriteLine("Debug is coming to town!");
    }


    static void AskToContinue()
    {
        Console.WriteLine("Continue with any key.");
        Console.ReadKey();
        Console.Clear();
    }
}

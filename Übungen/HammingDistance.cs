using System.Runtime.CompilerServices;

namespace Übungen;
internal class HammingDistance
{
    public static int GetHammingDistance(string s1, string s2)
    {
        string firstWord = s1.ToLower();
        string secondWord = s2.ToLower();
        int counter = 0;
        for (int i = 0; i < firstWord.Length; i++)
        {
            if (!firstWord[i].Equals(secondWord[i]))
            {
                counter++;
            }
        }
        return counter;
    }

    public static int GetMinHammingDistance(string s1, string s2)
    {
        string firstWord = s1.ToLower();
        string secondWord = s2.ToLower();

        string longerWord = s1.Length < s2.Length ? secondWord : firstWord;
        string shorterWord = s1.Length < s2.Length ? firstWord : secondWord;

        int n = longerWord.Length;
        int m = shorterWord.Length;

        int[] hammingDistances = new int[n + 1 - m];

        for (int i = 0; i+m-1 < n; i++)
        {
            
            hammingDistances[i] = GetHammingDistance(longerWord.Substring(i, m), shorterWord);
        }
        return hammingDistances.Min();
    }

    public static void AskForTwoWords(bool hasTheSameLength)
    {
        string firstWord, secondWord;

        if (hasTheSameLength)
        {

            do
            {

                Console.Write("Your first word:\t");
                firstWord = Console.ReadLine();
                Console.Write("Your second word:\t");
                secondWord = Console.ReadLine();
                if (firstWord.Length != secondWord.Length)
                {
                    Console.WriteLine("Words need to be the same length");
                }
            } while (firstWord.Length != secondWord.Length);

            Console.WriteLine("Hamming distance of {0} and {1} equals {2} \n", firstWord, secondWord, GetHammingDistance(firstWord, secondWord));
            return;
        }

        Console.Write("Your first word:\t");
        firstWord = Console.ReadLine();
        Console.Write("Your second word:\t");
        secondWord = Console.ReadLine();
        Console.WriteLine("Hamming distance of {0} and {1} equals {2} \n", firstWord, secondWord, GetMinHammingDistance(firstWord, secondWord));
    }


}

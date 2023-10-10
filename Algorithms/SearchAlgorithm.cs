namespace Algorithms;
internal class SearchAlgorithm
{

    public static void LinearSearchTime()
    {

        int[] bigIntArray = CreateBigArray();
        Random rand = new Random();
        Console.WriteLine("Started at");
        DateTime currentTime = DateTime.Now;
        Console.WriteLine(currentTime);

        LinearSearchFindFirst(bigIntArray, rand.Next(0, 10000));

        Console.WriteLine("Finished at");
        DateTime nextCurrentTime = DateTime.Now;
        Console.WriteLine(DateTime.Now);

        Console.WriteLine($"Duration was {nextCurrentTime - currentTime}.");

    }


    public static void LinearSearchAllTime()
    {

        int[] bigIntArray = CreateBigArray();
        Random rand = new Random();
        Console.WriteLine("Started at");
        DateTime currentTime = DateTime.Now;
        Console.WriteLine(currentTime);

        LinearSearchFindAll(bigIntArray, rand.Next(0, 10000));

        Console.WriteLine("Finished at");
        DateTime nextCurrentTime = DateTime.Now;
        Console.WriteLine(DateTime.Now);

        Console.WriteLine($"Duration was {nextCurrentTime - currentTime}.");
    }

    public static void BinarySearchTime()
    {
        int[] bigIntArray = CreateBigArray();
        Random rand = new Random();
        Array.Sort(bigIntArray); // use own sorting algorithm when implemented

        Console.WriteLine("Started at");
        DateTime currentTime = DateTime.Now;
        Console.WriteLine(currentTime);

        BinarySearch(bigIntArray, rand.Next(0, 10000));

        Console.WriteLine("Finished at");
        DateTime nextCurrentTime = DateTime.Now;
        Console.WriteLine(DateTime.Now);

        Console.WriteLine($"Duration was {nextCurrentTime - currentTime}.");
    }


    static int LinearSearchFindFirst(int[] arrayToSearch, int valueToFind)
    {
        for (int i = 0; i < arrayToSearch.Length; i++)
        {
            if (arrayToSearch[i] == valueToFind)
                return i;
        }
        return -1;
    }

    static string LinearSearchFindAll(int[] arrayToSearch, int valueToFind)
    {
        int count = 0;
        string indezes = "";

        for (int i = 0; i < arrayToSearch.Length; i++)
        {
            if (arrayToSearch[i] == valueToFind)
            {
                indezes += i.ToString() + "; ";
                count++;
            }
        }

        return indezes.Count() == 0 ? "Element not found" : $"Found at {indezes}";
    }

    static int BinarySearch(int[] arrayToSearch, int valueToFind)
    {
        int left = 0, right = arrayToSearch.Length - 1;

        while (left < right)
        {
            int mid = (left + right) / 2;

            if (arrayToSearch[mid] < valueToFind)
            {
                left = mid + 1;
            }
            else if (arrayToSearch[mid] > valueToFind)
            {
                right = mid - 1;
            }
            else 
            {
                return mid;
            }
        }

        return -1;
    }

        public static int[] CreateBigArray()
    {
        int[] bigIntArray = new int[10000000];

        for (int i = 0; i < bigIntArray.Length; i++)
        {
            Random rand = new Random();
            bigIntArray[i] = rand.Next(0, 10000);
        }

        return bigIntArray;
    }
}
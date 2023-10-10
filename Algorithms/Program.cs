namespace Algorithms
{
    public class Program
    {

        static void Main(string[] args)
        {
            /*
            #region Search Algorithm
            SearchAlgorithm.LinearSearchTime();

            SearchAlgorithm.LinearSearchAllTime();

            SearchAlgorithm.BinarySearchTime();
            #endregion
            */

            #region Sort Algorithm
            int[] array = CreateArray(10);
            foreach (int i in array)
            {
                Console.Write(i + "\t");
            }
            
            SortingAlgorithm.StupidSort(array);

            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            array = CreateArray(10);
            foreach (int i in array)
            {
                Console.Write(i + "\t");
            }
            SortingAlgorithm.BubbleSort(array);
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write(i + "\t");
            }
            #endregion


        }


        public static int[] CreateArray(int n)
        {
            int[] bigIntArray = new int[n];

            for (int i = 0; i < bigIntArray.Length; i++)
            {
                Random rand = new Random();
                bigIntArray[i] = rand.Next(0, 10000);
            }

            return bigIntArray;
        }
    }
}

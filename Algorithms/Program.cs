using System.Diagnostics;

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
            Stopwatch sw = new Stopwatch();

            int n = 10 * 1;
            int[] array = CreateArray(n);
            int[] bogusArray = CopyArray(array);
            int[] bubbleArray = CopyArray(array);
            int[] selectArray = CopyArray(array);
            int[] insertArray = CopyArray(array);

            Console.WriteLine("Created array with {0} values.",n);
            if (n < 15)
            foreach (int i in array)
            {
                Console.Write(i + "\t");
            }

            sw.Restart();
            SortingAlgorithm.StupidSort(bogusArray);
            sw.Stop();
            Console.WriteLine("\nArray sorted with BogusSort, approx duration {0}ms", sw.ElapsedMilliseconds);
            if (n < 15)
            foreach (int i in bogusArray)
            {
                Console.Write(i + "\t");
            }
            
            sw.Restart();
            SortingAlgorithm.BubbleSort(bubbleArray);
            sw.Stop();
            Console.WriteLine("\nArray sorted with BubbleSort, approx duration {0}ms", sw.ElapsedMilliseconds);
            if (n < 15)
            foreach (int i in bubbleArray)
            {
                Console.Write(i + "\t");
            }

            sw.Restart();
            SortingAlgorithm.SelectionSort(selectArray);
            sw.Stop();
            Console.WriteLine("\nArray sorted with SelectSort, approx duration {0}ms",sw.ElapsedMilliseconds);
            if (n < 15)
            foreach (int i in selectArray)
            {
                Console.Write(i + "\t");
            }

            sw.Restart();
            SortingAlgorithm.InsertionSort(insertArray);
            sw.Stop();
            Console.WriteLine("\nArray sorted with InsertSort, approx duration {0}ms", sw.ElapsedMilliseconds);
            if (n < 15)
                foreach (int i in insertArray)
                {
                    Console.Write(i + "\t");
                }

            #endregion


        }


        // helper method zu create large pseudorandom arrays
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

        // deep copy of an array
        
        public static int[] CopyArray(int[] array)
        {
            int[] tmp = array;
            int[] copy = tmp;

            return copy;
        }

    }
}

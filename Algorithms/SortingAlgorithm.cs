namespace Algorithms;

internal class SortingAlgorithm
{
    // properties of search algorithm:
    // stable -> order of same elements shouldn't change
    // in-place -> use only a small amount of extra storage space
    // least-possible comparissons, switching and moving


    // Bubble Sort

    public static void StupidSort(int[] array)
    {
        int i = 0;
        while (i < array.Length - 1)
        {
            if (array[i] > array[i + 1])
            {

                swap(array, i, i + 1);
                // restarts
                i = 0;
            }
            else
            {

                i++;
            }
        }

    }

    // instead of restarting, just iterate through, so the last entry will be the maximum and we can end the next loop sooner
    public static void BubbleSort(int[] array)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    swap(array, i, j);
                }
            }
        }

    }

    public static void SelectionSort(int[] array)
    {
        for (int pos = 0; pos < array.Length; pos++)
        {
            int min = pos;

            for (int i = pos + 1; i < array.Length; i++)
            {
                if (array[min] > array[i])
                {
                    min = i;
                }
            }

            swap(array,pos,min);
        }
    }


    public static void InsertionSort(int[] array)
    {
        for (int pos = 1; pos < array.Length; pos++)
        {
            int i = pos - 1;
            while (i >= 0 && array[i] > array[i+1])
            {
                swap(array, i, i + 1);
                i--;
            }
        }
    }


    // helper method SWAP to swap to elements in a array for BubbleSort
    public static void swap(int[] targetArray, int firstIndex, int secondIndex)
    {
        int temp = targetArray[firstIndex];
        targetArray[firstIndex] = targetArray[secondIndex];
        targetArray[secondIndex] = temp;
    }



}


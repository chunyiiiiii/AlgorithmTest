using System;

public class InsertSort
{
    public static int[] InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && key < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
        return arr;
    }

    public static void Main()
    {
        int[] array = { 12, 11, 13, 5, 6 };

        Console.WriteLine("Original Array:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int[] sortedArray = InsertionSort(array);

        Console.WriteLine("Sorted Array:");
        foreach (int num in sortedArray)
        {
            Console.Write(num + " ");
        }
        Console.ReadKey();
    }
}
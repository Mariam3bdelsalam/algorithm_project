using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static List<int> A = new List<int>() { 7, 9, 3, 4, 8, 15, 6, 10 };
        static List<int> sorted_A = new List<int>();

        static void Main(string[] args)
        {
            // Display initial list
            Console.WriteLine("Original List:");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }

            // Perform heap sort
            HeapSort(A);

            // Display sorted list
            Console.WriteLine("\nSorted List:");
            for (int i = sorted_A.Count - 1; i >= 0; i--)
            {
                Console.Write(sorted_A[i] + " ");
            }
        }

        static void MaxHeapify(List<int> array, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < array.Count && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < array.Count && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                Swap(array, i, largest);
                MaxHeapify(array, largest);
            }
        }

        static void BuildMaxHeap(List<int> array)
        {
            for (int i = (array.Count / 2) - 1; i >= 0; i--)
            {
                MaxHeapify(array, i);
            }
        }

        static void HeapSort(List<int> array)
        {
            BuildMaxHeap(array);

            while (array.Count > 0)
            {
                // Add the max element to sorted_A
                sorted_A.Add(array[0]);

                // Swap the first element with the last and remove the last
                Swap(array, 0, array.Count - 1);
                array.RemoveAt(array.Count - 1);

                // Restore the max-heap property
                MaxHeapify(array, 0);
            }
        }

        static void Swap(List<int> array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


internal class Program
{

    static int LinearSearch<T>(T[] arr, T x)
    {
        for(int i = 0; i < arr.Length; i++) 
            if (EqualityComparer<T>.Default.Equals(arr[i], x)) return i;
        return -1;
    }

    static int BinarySearch(int[] arr, int x)
    {
        int start = 0; int end = arr.Length - 1;

        while(start <= end)
        {
            int indexOfMiddle = start + (end - start) / 2;
            int middleElemnt = arr[indexOfMiddle];

            if(middleElemnt == x)
            {
                return indexOfMiddle;
            }

            else if (middleElemnt > x)
            {
                end = indexOfMiddle - 1;
            }
            else
            {
                start = indexOfMiddle + 1;
            }
        }
        return -1;

    }


    static void BubbleSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            for(int j = 0; j < arr.Length - i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    
    
    static void SelectionSortAscinding(int[] arr)
    {
        for(int i = 0; i < arr.Length - 1; i++)
        {
            int minimumIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minimumIndex])
                {
                    minimumIndex = j;
                }
            }
            if(minimumIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minimumIndex];
                arr[minimumIndex] = temp;
            }
        }

    }

    static void SelectionSortDesending(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int maximumIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] > arr[maximumIndex])
                {
                    maximumIndex = j;
                }
            }
            if (maximumIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[maximumIndex];
                arr[maximumIndex] = temp;
            }
        }

    }


    // 34, 7, 23, 32, 5, 62, 2, 14, 78, 45
    static void InsertionSort(int[] arr)
    {
       for(int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int k = i;

            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[j] > key)
                {
                    arr[k] = arr[j];
                    k--;
                }
                else
                    break;
            }
            arr[k] = key;
        }
    }


    static void AnotherInsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    // 2, 7, 23, 32, 5, 62, 2, 14, 78, 45
    // 2, 7, 23, 5, 32, 2, 14, 62, 45, 78 
    static void Main(string[] args)
    {
        //Console.WriteLine(LinearSearch(new int[5] {3, 6, 1, 9, 8}, 8));
        //Console.WriteLine(BinarySearch(new int[] { 1, 5, 9, 14, 20, 25, 33, 42, 57, 63, 74, 89 }, 1));

        int[] unsortedArray = { 34, 7, 23, 32, 5, 62, 2, 14, 78, 45 };
        MergeSort(unsortedArray, 0, unsortedArray.Length - 1);
        foreach (var item in unsortedArray)
        {
            Console.WriteLine(item);
        }


        Console.ReadKey();
    }




    static int BinSearch(int[] arr, int x )
    {
        int start = 0, end = arr.Length - 1;
        while(start <= end)
        {
            int indexOfMid = start + (end - start) / 2;
            int midNum = arr[indexOfMid];

            if(midNum == x)
                return indexOfMid;
            else if(x > midNum)
                start = indexOfMid + 1;
            else
                end = indexOfMid - 1;
        }
        return -1;
    }




    static void BubSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            for(int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }


    static void SelectionSort(int[] arr)
    {
        for(int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;

            for(int j = i + 1; j < arr.Length; j++)
            {
                if(arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if(minIndex != i)
            {
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }


    static void InsSort(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while(j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j]; // Shifiting
                j--;
            }
            arr[j + 1] = key;
        }
    }



    static void MergeSort(int[] arr, int leftIndex, int rightIndex)
    {
        if(rightIndex > leftIndex)
        {
            int mid = leftIndex + (rightIndex - leftIndex) / 2;

            MergeSort(arr, leftIndex, mid); // Sort The Left
            MergeSort(arr, mid + 1 , rightIndex);  // Sort The Righ
            Merge(arr, leftIndex, mid, rightIndex);

        }
    }

    static void Merge(int[] arr, int leftIndex, int mid, int rightIndex)
    {
        int leftSubArrSize = mid - leftIndex  + 1;
        int rightSubArrSize = rightIndex - mid;


        int[] leftSubArr = new int[leftSubArrSize];
        int[] rightSubArr = new int[rightSubArrSize];


        for (int i = 0; i < leftSubArrSize; i++)
            leftSubArr[i] = arr[i + leftIndex];
        for (int j = 0; j < rightSubArrSize; j++)
            rightSubArr[j] = arr[mid + 1 + j];


        int leftSumArrCount = 0;
        int rightSumArrCount = 0;
        int mainArrCount = leftIndex;


        while (leftSumArrCount < leftSubArrSize && rightSumArrCount < rightSubArrSize)
        {
            if (leftSubArr[leftSumArrCount] <= rightSubArr[rightSumArrCount])
            {
                arr[mainArrCount] = leftSubArr[leftSumArrCount];
                leftSumArrCount++;
            }
            else
            {
                arr[mainArrCount] = rightSubArr[rightSumArrCount];
                rightSumArrCount++;
            }
            mainArrCount++;
        }

        while (leftSumArrCount < leftSubArrSize)
        {
            arr[mainArrCount] = leftSubArr[leftSumArrCount];
            leftSumArrCount++;
            mainArrCount++;

        }
        while (rightSumArrCount < rightSubArrSize)
        {
            arr[mainArrCount] = rightSubArr[rightSumArrCount];
            rightSumArrCount++;
            mainArrCount++;

        }
    }
}


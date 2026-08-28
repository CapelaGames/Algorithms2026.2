using System.Collections.Concurrent;
using UnityEngine;

public class QuickSort : BubbleSort
{
    public override void Sort(int[] numbers, int n)
    {
        if (numbers != null && n > 0)
        {
            Sort(numbers, 0, n - 1);
        }
    }


    public void Sort(int[] numbers, int i, int j)
    {
        if (i >= j)
            return;

        int pivot = Partition(numbers, i, j);

        Sort(numbers, i, pivot - 1);
        Sort(numbers, pivot + 1, j);
    }

    private int Partition(int[] numbers, int left, int right)
    {
        int pivot = numbers[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (numbers[j] < pivot)
            {
                i++;
                Swap(numbers, i,j);
            }
        }

        Swap(numbers, i + 1, right);
        return i + 1;
    }
}

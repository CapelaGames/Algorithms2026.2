using UnityEngine;
using System.Diagnostics;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;
using System;

public class BubbleSort : MonoBehaviour
{

    [ContextMenu("Sort")]
    void Start()
    {
        int n = 10000000;
        int[] numbers = new int[n];
        for(int i = 0; i < n; i++)
        {
            numbers[i] = Random.Range(0, 2000000);
        }
        //PrintArray(numbers, n);


        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Sort(numbers, n);
        stopwatch.Stop();
        Debug.Log("TIME: " +stopwatch.ElapsedMilliseconds);


        for (int i = 0; i < n; i++)
        {
            numbers[i] = Random.Range(0, 2000000);
        }

        stopwatch = new Stopwatch();
        stopwatch.Start();
        Array.Sort(numbers);
        stopwatch.Stop();
        Debug.Log("TIME: " + stopwatch.ElapsedMilliseconds);
        //PrintArray(numbers, n);
    }

    void PrintArray(int[] numbers, int size)
    {
        Debug.Log(numbers);
        for (int i = 0; i < size; i++)
        {
            Debug.Log(numbers[i] + " ");
        }
    }

    public virtual void Sort(int[] numbers, int n)
    {
        int i, j;
        bool hasSwapped;

        for (i = 0; i < n -1; i++)
        {
            hasSwapped = false;

            for (j = 0; j < n - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    Swap(numbers, j, j + 1);
                    hasSwapped = true;
                }
            }
            if (!hasSwapped)
            {
                break;
            }
        }
    }

    public void Swap(int[] numbers, int i, int j)
    {
        // Regular way
        // int temp = numbers[i];
        // numbers[i] = numbers[j];
        // numbers[j] = temp;

        // Xor operator
        //numbers[i] = numbers[i] ^ numbers[j];
        //numbers[j] = numbers[i] ^ numbers[j];
        //numbers[i] = numbers[i] ^ numbers[j];

        // Tuple
        (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
    }
}

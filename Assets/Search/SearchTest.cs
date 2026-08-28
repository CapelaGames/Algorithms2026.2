using System;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class SearchTest : MonoBehaviour
{
    [ContextMenu("Run Search")]
    void Start()
    {
        // Set up
        Debug.Log("Generating array");
        int highestNumber = int.MaxValue;
        int[] numbers = new int[1000000];
        int loopCount = 100000;

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0,highestNumber);
        }
        int target = numbers[Random.Range(0, numbers.Length)];
        Array.Sort(numbers);

        // Linear Search
        Search search = new LinearSearch();
        int foundIndex = -1;
        Debug.Log("Starting Linear Search");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int index = 0; index < loopCount; index++)
        {
            foundIndex = search.Find(numbers, target);
        }
        stopwatch.Stop();
        Debug.Log("Found at index " + foundIndex + " and it took " + stopwatch.ElapsedMilliseconds);

        // Binary Search
        search = new BinarySearch();
        Debug.Log("Starting Binary Search");
        stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int index = 0; index < loopCount; index++)
        {
            foundIndex = search.Find(numbers, target);
        }
        stopwatch.Stop();
        Debug.Log("Found at index " + foundIndex + " and it took " + stopwatch.ElapsedMilliseconds);
    }
}

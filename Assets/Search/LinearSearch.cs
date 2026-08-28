using UnityEngine;

public abstract class Search
{
    public abstract int Find(int[] numbers, int target);
}

public class LinearSearch : Search
{
    public override int Find(int[] numbers, int target)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == target)
            {
                return i; 
            }
        }
        return -1; // should return index of target number
    }
}

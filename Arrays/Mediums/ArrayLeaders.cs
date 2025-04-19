//Problem Statement: Given an array, print all the elements which are leaders. A Leader is an element that is greater than all of the elements on its right side in the array.

namespace Arrays;
public partial class Arrays
{
    public static List<int> ArrayLeaders(int[] nums)
    {
        var maxSoFar = int.MinValue;
        var result = new List<int>();

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] > maxSoFar)
            {
                maxSoFar = nums[i];
                result.Add(nums[i]);
            }
        }
        result.Reverse();
        return result;
    }
}
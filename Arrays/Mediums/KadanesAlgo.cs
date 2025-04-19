namespace TheArtOfDSA;
public partial class Arrays
{
    // Kadanes with returning subarray of max sum
    public static List<int> KadanesAlgo(int[] nums)
    {
        int currentSum = 0, maxSum = nums[0];
        int startIndex = 0;
        int maxStartIndex = 0, maxEndIndex = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            currentSum += nums[i];
            if (currentSum > maxSum)
            {
                maxStartIndex = startIndex;
                maxEndIndex = i;
                maxSum = currentSum;
            }
            if (currentSum < 0)
            {
                currentSum = 0;
                startIndex = i + 1;
            }
        }

        var result = new List<int>();
        for (var i = maxStartIndex; i <= maxEndIndex; i++)
            result.Add(nums[i]);

        return result;
    }
}
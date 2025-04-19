namespace TheArtOfDSA;
public partial class Arrays
{
    public static int LongestSubarrayWithSumK(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        int longest = 0, sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sum == k)
                longest = i + 1;

            if (map.TryGetValue(sum - k, out var index))
                longest = Math.Max(longest, i - index);

            if (!map.ContainsKey(sum))
                map[sum] = i;
        }
        return longest;
    }

    public static int LongestSubarrayWithSumKNonNegative(int[] nums, int k)
    {
        int sum = 0, left = 0, right = 0, longest = 0;
        while (right < nums.Length)
        {
            sum += nums[right];

            if (sum > k && left <= right)
            {
                left++;
                sum -= nums[left];
            }

            if (sum == k)
                longest = Math.Max(longest, right - left + 1);

            right++;
        }
        return longest;
    }

}

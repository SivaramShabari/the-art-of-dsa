namespace TheArtOfDSA;
public partial class Arrays
{
    public static int LongestSubarray0Sum(int[] nums)
    {
        var sum = 0;
        var map = new Dictionary<int, int>();
        var longest = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];

            if (sum == 0)
                longest = i + 1;

            if (map.TryGetValue(sum, out var index))
                longest = Math.Max(longest, i - index);
            else
                map[sum] = i;
        }
        return longest;
    }
}
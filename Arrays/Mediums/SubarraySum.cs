namespace Arrays;
public partial class Arrays
{
    public static int SubarraySum(int[] nums, int k)
    {
        var sum = 0;
        var map = new Dictionary<int, int>();
        var result = 0;
        foreach (var num in nums) {
            sum += num;
            if (sum == k) result++;
            if (map.TryGetValue(sum - k, out var frequency))
                result += frequency;

            if(map.TryGetValue(sum, out var sumFrequency))
                map[sum] = sumFrequency + 1;
            else
                map[sum] = 1;
        }
        return result;
    }
}
namespace TheArtOfDSA;
public partial class Arrays
{
    public static int[] TwoSum(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.TryGetValue(k - nums[i], out var index))
                return [index, i];

            if (!dict.ContainsKey(nums[i]))
                dict[nums[i]] = i;
        }
        return [];
    }
}
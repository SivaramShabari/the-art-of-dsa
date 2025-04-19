namespace Arrays;
public partial class Arrays
{
    private const int MOD = 1_000_000_007;
    public static long CountInversionPair(int[] nums)
    {
        var arr = (int[])nums.Clone();
        return MergeSortCountPairs(arr, new int[nums.Length], 0, nums.Length - 1);
    }

    private static long MergeSortCountPairs(int[] nums, int[] temp, int start, int end)
    {
        if (start >= end) return 0;
        var mid = (start + end) / 2;

        var leftCount = MergeSortCountPairs(nums, temp, start, mid);
        var rightCount = MergeSortCountPairs(nums, temp, mid + 1, end);
        var mergedCount = MergeHalvesAndCountPairs(nums, temp, start, end);
        return leftCount + rightCount + mergedCount;
    }

    private static long MergeHalvesAndCountPairs(int[] nums, int[] temp, int start, int end)
    {
        var mid = (start + end) / 2;
        int p1 = start, p2 = mid + 1, p = start;
        var count = 0L;
        while (p1 <= mid && p2 <= end)
        {
            if (nums[p1] <= nums[p2])
                temp[p++] = nums[p1++];
            else
            {
                temp[p++] = nums[p2++];
                count = (count + mid - p1 + 1) % MOD;
            }
        }

        while (p1 <= mid)
            temp[p++] = nums[p1++];
        while (p2 <= end)
            temp[p++] = nums[p2++];

        for (var i = start; i <= end; i++)
            nums[i] = temp[i];

        return count;
    }
}
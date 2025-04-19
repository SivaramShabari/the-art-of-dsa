namespace TheArtOfDSA;
public partial class Arrays
{
    public static long CountReversePairs(int[] nums)
    {
        var arr = (int[])nums.Clone();
        return MergeSortReversePairs(arr, new int[nums.Length], 0, nums.Length - 1);
    }

    private static long MergeSortReversePairs(int[] nums, int[] temp, int start, int end)
    {
        if (start >= end) return 0;
        var mid = (start + end) / 2;
        var leftCount = MergeSortReversePairs(nums, temp, start, mid);
        var rightCount = MergeSortReversePairs(nums, temp, mid + 1, end);
        var count = CountReversePairs(nums, start, mid, end);
        MergeHalves(nums, temp, start, end);
        return (leftCount + rightCount + count) % MOD;
    }

    private static long CountReversePairs(int[] nums, int start, int mid, int end)
    {
        int p1 = start, p2 = mid + 1;
        var count = 0L;
        while (p1 <= mid)
        {
            while (p2 <= end && (long)nums[p1] > 2L * (long)nums[p2]) p2++;
            count = (count + p2 - mid - 1) % MOD;
            p1++;
        }
        return count;
    }

    private static void MergeHalves(int[] nums, int[] temp, int start, int end)
    {
        var mid = (start + end) / 2;
        int p1 = start, p2 = mid + 1, p = start;
        while (p1 <= mid && p2 <= end)
        {
            if (nums[p1] <= nums[p2])
                temp[p++] = nums[p1++];
            else
                temp[p++] = nums[p2++];
        }

        while (p1 <= mid)
            temp[p++] = nums[p1++];
        while (p2 <= end)
            temp[p++] = nums[p2++];

        for (var i = start; i <= end; i++)
            nums[i] = temp[i];
    }
}
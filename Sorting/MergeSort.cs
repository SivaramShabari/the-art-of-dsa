namespace Sorting;

public partial class Sorting
{
    public static void MergeSort(int[] nums)
    {
        MegeSortHelper(nums, new int[nums.Length], 0, nums.Length - 1);
    }

    private static void MegeSortHelper(int[] nums, int[] temp, int start, int end)
    {
        if (start >= end) return;
        int mid = (start + end) / 2;
        MegeSortHelper(nums, temp, start, mid);
        MegeSortHelper(nums, temp, mid + 1, end);
        MergeHalves(nums, temp, start, end);
        Console.WriteLine();
        for (var i = start; i <= end; i++)
            Console.Write(temp[i] + " ");
        Console.WriteLine();
    }

    private static void MergeHalves(int[] nums, int[] temp, int start, int end)
    {
        int mid = (start + end) / 2;
        int i = start, j = mid + 1, k = start;
        while (i <= mid && j <= end)
        {
            if (nums[i] <= nums[j])
                temp[k++] = nums[i++];

            if (nums[j] < nums[i])
                temp[k++] = nums[j++];
        }
        while (i <= mid)
            temp[k++] = nums[i++];
        while (j <= end)
            temp[k++] = nums[j++];

        for (i = start; i <= end; i++)
            nums[i] = temp[i];
    }
}
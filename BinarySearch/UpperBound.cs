namespace TheArtOfDSA;

public partial class BinarySearch
{
    public static int UpperBound(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] <= target)
                left = mid + 1;
            else
            {
                if (mid == 0 || nums[mid - 1] <= target)
                    return mid;
                right = mid - 1;
            }
        }
        return left;
    }
}
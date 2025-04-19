namespace TheArtOfDSA;

public partial class BinarySearch
{
    public static int LowerBound(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (nums[mid] >= target)
            {
                if (mid == 0 || nums[mid - 1] < target)
                    return mid;
                right = mid - 1;
            }
            else
                left = mid + 1;
        }
        return left;
    }

    [Test]
    public static void LowerBoundTests()
    {
        TestUtils.AssertEqual(0, LowerBound([], 6), "Empty array returns 0");
        TestUtils.AssertEqual(0, LowerBound([100, 200], 6));
        TestUtils.AssertEqual(5, LowerBound([1, 2, 3, 4, 5], 6));
        TestUtils.AssertEqual(1, LowerBound([1, 2, 2, 3], 2));
        TestUtils.AssertEqual(0, LowerBound([2, 2, 2, 2], 2));
        TestUtils.AssertEqual(0, LowerBound([2, 3, 4, 5], 2));
        TestUtils.AssertEqual(2, LowerBound([1, 1, 2, 3, 3], 2));
        TestUtils.AssertEqual(3, LowerBound([3, 5, 8, 15, 19], 9));
        TestUtils.AssertEqual(0, LowerBound([3, 5, 8, 15, 19], 1));
    }
}
using System.Collections.Concurrent;

namespace TheArtOfDSA;
public partial class BinarySearch
{
    public static int KthMissingNumber(int[] nums, int k)
    {
        if (nums.Length < 1 || nums[0] < k) return k;
        var lowerBoundIndex = LowerBoundKthMissing(nums, k);
        return k + lowerBoundIndex + 1;
    }

    private static int LowerBoundKthMissing(int[] nums, int k)
    {
        int left = 0, right = nums.Length - 1, answer = 0;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] <= k)
            {
                answer = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }
        return answer;
    }

    [Test]
    public static void KthMissingNumber_Tests_1()
    {
        TestUtils.AssertEqual(1, KthMissingNumber([2, 3, 4, 5], 1));
    }

    [Test]
    public static void KthMissingNumber_Tests_2()
    {
        TestUtils.AssertEqual(5, KthMissingNumber([2, 3, 4, 5], 3));
    }

    [Test]
    public static void KthMissingNumber_Tests_3()
    {
        TestUtils.AssertEqual(9, KthMissingNumber([2, 3, 4, 5], 5));
    }

    [Test]
    public static void LowerBoundKthMissing_Test_1()
    {
        TestUtils.AssertEqual(0, LowerBoundKthMissing([2, 3, 4, 5], 1));
        TestUtils.AssertEqual(0, LowerBoundKthMissing([2, 3, 4, 5], 2));
        TestUtils.AssertEqual(1, LowerBoundKthMissing([2, 3, 4, 5], 3));
        TestUtils.AssertEqual(2, LowerBoundKthMissing([2, 3, 4, 5], 4));
        TestUtils.AssertEqual(3, LowerBoundKthMissing([2, 3, 4, 5], 5));
        TestUtils.AssertEqual(4, LowerBoundKthMissing([2, 3, 4, 5, 7], 6));
        TestUtils.AssertEqual(4, LowerBoundKthMissing([2, 3, 4, 5, 7], 8));
        ConcurrentDictionary<int, int> keys = [];
    }
}
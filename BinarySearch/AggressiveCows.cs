using TheArtOfDSA;
/*
    The array contains "positions" of stalls in random order and we have to maximise the min distance between any 2 cows
    First sort the sheds, because we just need max distance
    Then for each min value find if we can place cows in asc order of shed with chosen value
    Do binary search on the min value we choose

*/
public partial class BinarySearch
{
    public static int AggressiveCows(int[] sheds, int cowCount)
    {
        Array.Sort(sheds);
        var answer = 0;
        int left = 1, right = sheds[^1] - sheds[0];
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (CanPlaceCowWithGivenMaxMinDistance(mid, sheds, cowCount))
            {
                answer = mid;
                left = mid + 1;
            }
            else
                right = mid - 1;
        }
        return answer;
    }

    private static bool CanPlaceCowWithGivenMaxMinDistance(int maxMinDistance, int[] sheds, int cowCount)
    {
        var lastCowPosition = 0;
        var remainingCows = cowCount - 1; // one cow is placed in index 0
        for (var i = 1; i < sheds.Length && remainingCows > 0; i++)
        {
            if (sheds[i] - sheds[lastCowPosition] >= maxMinDistance)
            {
                remainingCows--;
                lastCowPosition = i;
            }
        }

        return remainingCows == 0;
    }

    [Test]
    public static void CanPlaceCowWithGivenMaxMinDistance_Tests()
    {
        TestUtils.AssertEqual(true, CanPlaceCowWithGivenMaxMinDistance(1, [0, 3, 4, 7, 9, 10], 4));
        TestUtils.AssertEqual(true, CanPlaceCowWithGivenMaxMinDistance(3, [0, 3, 4, 7, 9, 10], 4));
        TestUtils.AssertEqual(false, CanPlaceCowWithGivenMaxMinDistance(4, [0, 3, 4, 7, 9, 10], 4));

        TestUtils.AssertEqual(true, CanPlaceCowWithGivenMaxMinDistance(4, [1, 2, 3, 4, 6], 2));
        TestUtils.AssertEqual(false, CanPlaceCowWithGivenMaxMinDistance(6, [1, 2, 3, 4, 6], 2));

        TestUtils.AssertEqual(true, CanPlaceCowWithGivenMaxMinDistance(3, [1, 2, 4, 8, 9], 3));
        TestUtils.AssertEqual(false, CanPlaceCowWithGivenMaxMinDistance(4, [1, 2, 8, 8, 9], 3));

    }

    [Test]
    public static void AggressiveCows_Tests()
    {
        TestUtils.AssertEqual(3, AggressiveCows([0, 3, 4, 7, 10, 9], 4));
        TestUtils.AssertEqual(5, AggressiveCows([4, 2, 1, 3, 6], 2));
        TestUtils.AssertEqual(3, AggressiveCows([1, 2, 8, 4, 9], 3));
    }
}
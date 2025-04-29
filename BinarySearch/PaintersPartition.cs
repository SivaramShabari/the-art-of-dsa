using TheArtOfDSA;

public partial class BinarySearch
{
    public static int PaintersPartition(int[] times, int h)
    {
        var min = 0;
        var max = times.Sum();
        while (min <= max)
        {
            var mid = min + (max - min) / 2;
            if (IsValidMinTime(times, h, mid))
                max = mid - 1;
            else
                min = mid + 1;
        }

        return min;
    }

    static bool IsValidMinTime(int[] times, int h, int minTime)
    {
        var timeTaken = 0;
        var paintersRemaining = h;
        for (var i = 0; i < times.Length; i++)
        {
            timeTaken += times[i];
            if (timeTaken > minTime)
            {
                paintersRemaining--;
                if (paintersRemaining <= 0)
                    return false;
                timeTaken = times[i];
            }
        }
        return true;
    }

    [Test]
    public static void PaintersPartitionTests()
    {
        TestUtils.AssertEqual(60, PaintersPartition([10, 20, 30, 40], 2));
        TestUtils.AssertEqual(10, PaintersPartition([5, 5, 5, 5], 2));
        TestUtils.AssertEqual(true, IsValidMinTime([10, 20, 30, 40], 2, 60));
        TestUtils.AssertEqual(true, IsValidMinTime([10, 20, 30, 40], 2, 100));
        TestUtils.AssertEqual(false, IsValidMinTime([10, 20, 30, 40], 2, 50));
        TestUtils.AssertEqual(false, IsValidMinTime([10, 20, 30, 40], 2, 30));
    }
}
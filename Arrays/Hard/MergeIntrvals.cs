namespace TheArtOfDSA;
public partial class Arrays
{
    public static int[][] MergeIntervals(int[][] intervals)
    {
        Array.Sort(intervals,
            (a, b) => a[0].CompareTo(b[0]) != 0 ?
                        a[0].CompareTo(b[0]) :
                        a[1].CompareTo(b[1]));
        var result = new List<int[]>();
        int prevStart = intervals[0][0], prevEnd = intervals[0][1];
        for (var i = 1; i < intervals.Length; i++)
        {
            int currStart = intervals[i][0], currEnd = intervals[i][1];
            if (currStart <= prevEnd)
            {
                prevStart = Math.Min(currStart, prevStart);
                prevEnd = Math.Max(currEnd, prevEnd);
            }
            else
            {
                result.Add([prevStart, prevEnd]);
                prevStart = currStart;
                prevEnd = currEnd;
            }
        }
        result.Add([prevStart, prevEnd]);
        return result.ToArray();

    }
}
namespace Arrays;
public partial class Arrays
{
    public static int LongestConsecutiveSequence(int[] nums)
    {
        var set = new HashSet<int>(nums);
        var longest = 0;
        foreach (var num in nums)
        {
            if (!set.Contains(num - 1))
            {
                var currNum = num;
                while (set.Contains(currNum))
                    currNum++;
                longest = Math.Max(currNum - num, longest);
            }
        }
        return longest;
    }
}
namespace TheArtOfDSA;
public partial class Arrays
{
    // FindMaxConsecutiveOnes
    public static int FindMaxConsecutiveOnes(int[] nums)
    {
        int maxSoFar = 0, curr = 0;
        foreach (var num in nums)
        {
            if (num == 1)
            {
                curr++;
                maxSoFar = Math.Max(maxSoFar, curr);
            }
            else
                curr = 0;
        }
        return maxSoFar;
    }


}
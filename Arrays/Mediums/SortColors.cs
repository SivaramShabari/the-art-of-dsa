namespace TheArtOfDSA;
public partial class Arrays
{
    public static void SortColors(int[] nums)
    {
        var colorCount = new int[3];
        foreach (var color in nums)
            colorCount[color]++;

        int i = 0, j = 0; ;
        while (i < 3)
        {
            if (colorCount[i] == 0)
                i++;
            else
            {
                nums[j++] = i;
                colorCount[i]--;
            }
        }
    }
}


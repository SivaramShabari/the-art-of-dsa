namespace TheArtOfDSA;
public partial class Arrays
{
    public static List<int> MajorityElement2(int[] nums)
    {
        int? candidate1 = null, candidate2 = null;
        int c1 = 0, c2 = 0;
        foreach (var num in nums)
        {
            if (candidate1 == num)
                c1++;
            else if (candidate2 == num)
                c2++;
            else if (c1 == 0)
            {
                candidate1 = num;
                c1 = 1;
            }
            else if (c2 == 0)
            {
                candidate2 = num;
                c2 = 1;
            }
            else
            {
                c1--;
                c2--;
            }
        }

        c1 = 0;
        c2 = 0;
        foreach (var num in nums)
        {
            if (num == candidate1)
                c1++;
            else if (num == candidate2)
                c2++;
        }

        var result = new List<int>();
        if (candidate1.HasValue && c1 > nums.Length / 3) result.Add(candidate1.Value);
        if (candidate2.HasValue && c2 > nums.Length / 3) result.Add(candidate2!.Value);
        return result;
    }
}
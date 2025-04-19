namespace Arrays;
public partial class Arrays
{
    public static int[] MissingAndRepeatingNums(int[] nums)
    {
        var xor = 0;

        foreach (var i in Enumerable.Range(1, nums.Length))
        {
            xor ^= nums[i - 1];
            xor ^= i;
        }

        var diffBitMask = 1;
        while ((xor & diffBitMask) == 0)
            diffBitMask <<= 1;

        int xor0 = 0, xor1 = 0;
        foreach (var i in Enumerable.Range(1, nums.Length))
        {
            if ((nums[i - 1] & diffBitMask) == 0)
                xor0 ^= nums[i - 1];
            else
                xor1 ^= nums[i - 1];

            if ((i & diffBitMask) == 0)
                xor0 ^= i;
            else
                xor1 ^= i;
        }

        if (nums.Count(num => num == xor0) == 2)
            return [xor0, xor1];

        return [xor1, xor0];
    }
}
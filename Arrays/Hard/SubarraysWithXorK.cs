namespace Arrays;
public partial class Arrays
{
    public static int SubarrayWithXorK(int[] nums, int k)
    {
        int result = 0, xor = 0;
        var map = new Dictionary<int, int>(){
            {0, 1}
        };

        foreach (var num in nums)
        {
            xor ^= num;
            if (map.TryGetValue(xor ^ k, out var frequency))
                result += frequency;

            if (map.TryGetValue(xor, out var xorFrequency))
                map[xor] = xorFrequency + 1;
            else
                map[xor] = 1;
        }
        return result;
    }
}
namespace Arrays;
public partial class Arrays
{
    public static int RemoveDuplicates(int[] nums)
    {
        int k = 1, prev = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != prev)
            {
                nums[k++] = nums[i];
                prev = nums[i];
            }
        }
        return k;
    }
}
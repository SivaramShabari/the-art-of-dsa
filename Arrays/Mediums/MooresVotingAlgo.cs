namespace TheArtOfDSA;
public partial class Arrays
{
    public static int MajorityElement(int[] nums, bool shouldValidate = false)
    {
        int candidate = nums[0], count = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == candidate)
                count++;
            else
            {
                count--;
                if (count == 0)
                {
                    candidate = nums[i];
                    count = 1;
                }
            }
        }
        if (shouldValidate)
        {
            count = 0;
            foreach (var num in nums)
                if (num == candidate) count++;
            if (count <= (nums.Length / 2))
                throw new Exception("No majority element found!");
        }

        return candidate;
    }
}
namespace TheArtOfDSA;
public partial class Arrays
{
    public static IList<IList<int>> FourSum(int[] nums, int target)
    {
        if (nums.Length < 4) return [];
        Array.Sort(nums);
        var result = new List<IList<int>>();
        for (var i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            for (var j = i + 1; j < nums.Length - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                int left = j + 1, right = nums.Length - 1;
                long currTarget = (long)target - nums[i];
                while (left < right)
                {
                    long sum = (long)nums[j] + nums[left] + nums[right];

                    if (sum == currTarget)
                    {
                        result.Add([nums[i], nums[j], nums[left], nums[right]]);
                        int leftVal = nums[left], rightVal = nums[right];
                        while (left < right && nums[left] == leftVal) left++;
                        while (right > left && nums[right] == rightVal) right--;
                    }
                    else if (sum > currTarget) right--;
                    else left++;
                }
            }
        }
        return result;
    }
}
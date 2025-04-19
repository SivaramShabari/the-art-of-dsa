namespace TheArtOfDSA;
public partial class Arrays
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();
        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int left = i + 1, right = nums.Length - 1;
            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add([nums[i], nums[left], nums[right]]);
                    int leftVal = nums[left], rightVal = nums[right];
                    while (left < right && nums[left] == leftVal) left++;
                    while (right > left && nums[right] == rightVal) right--;
                }

                else if (sum > 0) right--;
                else left++;
            }
        }
        return result;
    }
}
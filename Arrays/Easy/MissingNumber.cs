namespace Arrays;
public partial class Arrays
{
    /*
        Given an array nums containing n distinct numbers in the range [0, n], return the only number in the range that is missing from the array.
    */
    public int MissingNumber(int[] nums)
    {
        var n = nums.Length;
        var expectedSum = (n * (n + 1)) / 2;
        var actualSum = nums.Sum();
        return expectedSum - actualSum;
    }
}
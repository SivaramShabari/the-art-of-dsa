namespace Arrays;

/*

    Find dropIndex => where nums[dropIndex] > nums[dropIndex - 1]
    If dropIndex == 0, ie descending order i/p then return asc order
    Else:
        Reverse the array startint at dropIndex till last
        Find the smallest element larger than nums[dropIndex - 1] to swap with nums[dropIndex - 1] 
        Swap them

        Why this is the case is from this reasoning:
            We reverse the last past because the last past is in desc order for sure (that is how we find dropIndex)
            By reversing we get the least combindation for last dropIndex-last permutation
            But this is not next one
            The next one is larger than orig number by least
            So we can swap the dropIndex-1 digit with the digit that is larger
            Larger will exist for sure because of the condition nums[dropIndex] > nums[dropIndex - 1]
            The condn also is  nums[dropIndex - 1] < nums[dropIndex]

*/
public partial class Arrays
{
    public static void NextPermutation(int[] nums)
    {
        int dropIndex = nums.Length - 1;
        while (dropIndex > 0)
        {
            if (nums[dropIndex] > nums[dropIndex - 1]) break;
            dropIndex--;
        }

        if (dropIndex == 0)
            Array.Reverse(nums);

        else
        {
            Array.Reverse(nums, dropIndex, nums.Length - dropIndex);
            var greaterDigit = dropIndex;
            while (nums[greaterDigit] <= nums[dropIndex - 1])
                greaterDigit++;
            (nums[greaterDigit], nums[dropIndex - 1]) = (nums[dropIndex - 1], nums[greaterDigit]);
        }
    }
}
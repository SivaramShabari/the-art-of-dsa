namespace TheArtOfDSA;
public partial class Arrays
{
    /*
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
        Note that you must do this in-place without making a copy of the array.
    */
    public static void MoveZeroes(int[] nums)
    {
        int ptr1 = 0, ptr2 = 0;
        while (ptr2 < nums.Length)
        {
            if (nums[ptr2] != 0)
            {
                (nums[ptr1], nums[ptr2]) = (nums[ptr2], nums[ptr1]);
                ptr1++;
                ptr2++;
            }
            else ptr2++;
        }
    }
}
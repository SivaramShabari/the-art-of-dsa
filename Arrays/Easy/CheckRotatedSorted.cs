namespace Arrays;
public partial class Arrays
{
    public bool Check(int[] nums)
    {
        var rotationCount = 0;
        for (var i = 0; i < nums.Length - 1; i++)
            if (nums[i] > nums[i + 1] && rotationCount++ > 0)
                return false;

        return rotationCount == 0 || nums[0] >= nums[^1];
    }
}


/*
Check for all return values: they are same for all cases => nums[0] < nums[last] if rotation is there
If no rotation, ret true, if values are not sorted then false

Sln:
    Find if arr is sorted
    IF not
        Find rotation position
    If not sorted even after rotation position != -1, ret false
    Finally validate rotation position (rp):
        if(arr[rp] == 0) => if(arr[rp] > arr[last]) ret true else false
        if(arr[rp] == last - 2) => if(arr[last] < arr[0]) ret true else false
        if(arr[0] >= arr[last]) ret ture else false

Mistakes:
    Check for >= conditions too. This wasted a lot of time.
    Also check for conditions for all cases


Thinking:
If array is not rotated => arr[i] < arr[i + 1]
If arr[i] > arr[i + 1]:
    either the position is rotated position
    We can check for this if

1 2 3 4 5 6
4 5 6 1 2 3
6 1 2 3 4 5
2 3 4 5 6 1

2 1 3 4



*/
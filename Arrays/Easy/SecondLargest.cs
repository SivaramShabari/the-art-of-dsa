namespace TheArtOfDSA;
public partial class Arrays
{
    public static int[] GetSecondExtreme(int[] nums)
    {
        return [GetSecondSmallest(nums), GetSecondLargest(nums)];
    }

    public static int GetSecondLargest(int[] nums)
    {
        int largest = int.MinValue, secondLargest = int.MinValue;
        foreach (var num in nums)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
                secondLargest = num;
        }
        if (secondLargest == int.MinValue) return -1;
        return secondLargest;
    }

    public static int GetSecondSmallest(int[] nums)
    {
        int smallest = int.MaxValue, secondSmallest = int.MaxValue;
        foreach (var num in nums)
        {
            if (num < smallest)
            {
                secondSmallest = smallest;
                smallest = num;
            }
            else if (num < secondSmallest && num != smallest)
                secondSmallest = num;
        }
        if (secondSmallest == int.MaxValue) return -1;
        return secondSmallest;
    }
}
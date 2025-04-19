
namespace TheArtOfDSA;
public partial class Arrays
{
    public static int SingleNumber(int[] nums)
    {
        var singleOccurenceNum = 0;
        foreach (var num in nums)
            singleOccurenceNum ^= num;
        return singleOccurenceNum;
    }
}
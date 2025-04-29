namespace TheArtOfDSA;
public partial class BinarySearch
{
    public static int MinEatingSpeed(int[] piles, int h)
    {
        var min = 0;
        var max = piles.Max();
        while (min <= max)
        {
            var mid = min + (max - min) / 2;
            if (IsValidMinCount(mid))
                max = mid - 1;
            else
                min = mid + 1;
        }

        return min;

        bool IsValidMinCount(int countPerHour)
        {
            if (countPerHour <= 0) return false;
            var hoursTaken = 0;
            foreach (var pile in piles)
                hoursTaken += (int)Math.Ceiling((decimal)pile / countPerHour);
            return hoursTaken <= h;
        }
    }
}
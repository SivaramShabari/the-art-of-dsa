namespace Arrays;
public partial class Arrays
{
    public static int MaxProfit(int[] prices)
    {
        var minSoFar = int.MaxValue;
        var maxProfit = 0;
        foreach (var price in prices)
        {
            minSoFar = Math.Min(minSoFar, price);
            maxProfit = Math.Max(maxProfit, price - minSoFar);
        }
        return maxProfit;
    }
}
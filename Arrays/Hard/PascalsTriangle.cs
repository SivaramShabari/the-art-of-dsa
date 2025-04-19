namespace TheArtOfDSA;
public partial class Arrays
{
    public static IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> result = [[1]];
        for (var i = 1; i < numRows; i++)
        {
            List<int> currRow = [1];
            for (var j = 1; j < i; j++)
                currRow.Add(result[i - 1][j - 1] + result[i - 1][j]);
            currRow.Add(1);
            result.Add(currRow);
        }
        return result;
    }
}
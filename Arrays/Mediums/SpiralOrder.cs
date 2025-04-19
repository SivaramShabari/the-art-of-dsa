namespace TheArtOfDSA;
public partial class Arrays
{
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int layers = (Math.Min(m, n) + 1) / 2;
        var result = new List<int>();
        for (var layer = 0; layer < layers; layer++)
        {
            // top left to top right
            for (var i = layer; i < n - layer; i++)
                result.Add(matrix[layer][i]);

            // top right to bottom right
            for (var i = layer + 1; i < m - layer; i++)
                result.Add(matrix[i][n - 1 - layer]);

            // bottom right to bottom left
            for (var i = n - layer - 2; i >= layer && m - layer - 2 >= layer; i--)
                result.Add(matrix[m - layer - 1][i]);

            // bottom left to top left
            for (var i = m - layer - 2; i > layer && n - layer - 2 >= layer; i--)
                result.Add(matrix[i][layer]);
        }
        return result;
    }
}
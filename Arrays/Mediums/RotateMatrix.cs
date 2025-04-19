namespace Arrays;
public partial class Arrays
{
    public static void Rotate(int[][] matrix)
    {
        var n = matrix.Length;
        int layers = (n + 1) / 2;
        for (var layer = 0; layer < layers; layer++)
        {
            int left = layer, top = layer, right = n - layer - 1, bottom = n - layer - 1;
            for (var i = 0; i < n - 1 - 2 * layer; i++)
            {
                var topLeft = matrix[top][left + i];
                var topRight = matrix[top + i][right];
                var bottomRight = matrix[bottom][right - i];
                var bottomLeft = matrix[bottom - i][left];

                matrix[top + i][right] = topLeft;
                matrix[top][left + i] = bottomLeft;
                matrix[bottom][right - i] = topRight;
                matrix[bottom - i][left] = bottomRight;
            }
        }
    }
}
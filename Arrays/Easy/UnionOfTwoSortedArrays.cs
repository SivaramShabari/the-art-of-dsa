namespace Arrays;
public partial class Arrays
{
    // Union of Two Sorted Arrays
    public static List<int> UnionOfSortedArrays(int[] arr1, int[] arr2)
    {
        List<int> result = [];
        int ptr1 = 0, ptr2 = 0;
        while (ptr1 < arr1.Length && ptr2 < arr2.Length)
        {
            var value = 0;
            if (arr1[ptr1] < arr2[ptr2])
                value = arr1[ptr1++];
            else if (arr2[ptr2] < arr1[ptr1])
                value = arr1[ptr1++];
            else
            {
                value = arr1[ptr1];
                ptr1++;
                ptr2++;
            }

            if (result.Count == 0 || result[^1] != value)
                result.Add(value);
        }

        while (ptr1 < arr1.Length)
        {
            if (result.Count == 0 || arr1[ptr1] != result[^1])
                result.Add(arr1[ptr1]);
            ptr1++;
        }

        while (ptr2 < arr2.Length)
        {
            if (result.Count == 0 || arr2[ptr2] != result[^1])
                result.Add(arr2[ptr2]);
            ptr2++;
        }

        return result;
    }
}
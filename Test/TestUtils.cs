namespace TheArtOfDSA;

public static class TestUtils
{
    public static void AssertEqual<T>(T expected, T actual, string testName = "")
    {
        if (typeof(IEnumerable<T>).IsAssignableFrom(typeof(T)) && !(expected is string))
        {
            Console.WriteLine($"⚠️ {testName} uses wrong overload for collections.");
            return;
        }

        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            Fail(expected, actual, testName);
        else
            Pass(testName);
    }

    public static void AssertEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, string testName = "")
    {
        if (!expected.SequenceEqual(actual))
            Fail(string.Join(", ", expected), string.Join(", ", actual), testName);
        else
            Pass(testName);
    }

    private static void Pass(string testName)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✅ {testName} passed.");
        Console.ResetColor();
    }

    private static void Fail(object expected, object actual, string testName)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ {testName} FAILED. Expected: {expected}, Got: {actual}");
        Console.ResetColor();
    }
}

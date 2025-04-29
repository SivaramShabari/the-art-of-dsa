namespace TheArtOfDSA;
public static class TestRunner
{
    public static void RunAllTests()
    {
        Console.Clear();
        var testMethods = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(asm => asm.GetTypes())
            .Where(t => t.IsClass && t.IsAbstract == false) // match your namespace
            .SelectMany(t => t.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic))
            .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0);
        int passed = 0, failed = 0;
        foreach (var method in testMethods)
        {
            try
            {
                method.Invoke(null, null);
                passed++;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ FAILED - {method.DeclaringType?.Name}.{method.Name}: {ex.InnerException?.Message}");
                Console.ResetColor();
                failed++;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        if (testMethods.Count() == passed)
            Console.WriteLine("All tests cases executed and passed!");
        else
        {
            Console.WriteLine($"\n{testMethods.Count()} tests executed. \n{passed} passed.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{failed} failed");
        }
        Console.ResetColor();
    }
}

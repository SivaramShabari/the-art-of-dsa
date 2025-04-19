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

        foreach (var method in testMethods)
        {
            Console.WriteLine($"Running {method.Name}... ");
            try
            {
                method.Invoke(null, null);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[FAIL] {method.DeclaringType?.Name}.{method.Name}: {ex.InnerException?.Message}");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nAll tests executed.");
        Console.ResetColor();
    }
}

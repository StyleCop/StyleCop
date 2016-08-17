/// <summary>
/// Foo class.
/// </summary>
internal partial class Foo
{
    /// <summary>
    /// A string variable.
    /// </summary>
    private string a;

    /// <summary>
    /// Does something.
    /// </summary>
    public void DoSomething()
    {
        DoNothing(a.Length).Clone(); // <-- Doesn't raise the SA1101 warning!
        DoNothing(a.Length); // <-- Raises the SA1101 warning!
    }

    /// <summary>
    /// Does nothing.
    /// </summary>
    /// <typeparam name="T">Type of the ignored parameter.</typeparam>
    /// <param name="ignored">The ignored parameter.</param>
    /// <returns>An empty string.</returns>
    private static string DoNothing<T>(T ignored)
    {
        return String.Empty;
    }
}
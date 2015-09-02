class Program
{
    static void Main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        foreach (Type curType in (from type in assembly.GetTypes() where (type.IsClass) select type))
        {
        }
    }
}

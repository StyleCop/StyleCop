#region Normal Classes

public class FilterExceptions
{
    public void Test()
    {
        try
        {
            Console.Write("Test");
        }
        catch (Exception) when (true)
        {
        }
    }

    public void TestWhenAsVariableName()
    {
        var when = new XElement("someelement");
    }
}
#endregion
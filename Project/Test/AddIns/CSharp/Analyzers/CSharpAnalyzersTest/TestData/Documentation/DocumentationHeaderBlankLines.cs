namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// Valid header with no blank lines.
    /// </summary>
    public class Class1
    {
    }

    ///         
    /// <summary>
    /// Invalid header
    /// </summary>
    public class Class2
    {
    }

    /// <summary>
    ///    
    /// Invalid header
    /// </summary>
    public class Class3
    {
    }

    /// <summary>
    /// Invalid header
    /// 			
    /// </summary>
    public class Class4
    {
    }

    /// <summary>
    /// Invalid header
    /// </summary>
    /// 
    public class Class5
    {
    }

///
/// 
    /// <summary>
    /// Invalid header
    /// </summary>
    public class Class6
    {
    }

    /// <summary>
    ///
    /// Invalid header
    /// 
    /// </summary>
    public class Class7
    {
    }

    /// <summary>
    ///
    ///
   /// 
    /// Invalid header
    /// </summary>
    public class Class8
    {
    }
}

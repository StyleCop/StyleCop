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

    /// <summary>
    /// valid header
    /// </summary>
    /// <example> 
    /// <code>
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// 
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// </code>
    /// </example>   
    public class Class9
    {
    }

    /// <summary>
    /// invalid header
    /// </summary>
    /// <example> 
    /// <code>
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// } </code>
    /// 
    /// <code>
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class Class10
    {
    }

    /// <summary>
    /// valid header
    /// </summary>
    /// <example> 
    /// <code>
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// } </code><code><code><code>
    /// </code></code>
    /// 
    /// </code>
    /// <code>
    /// 
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class Class11
    {
    }

    /// <summary>
    /// valid header
    /// </summary>
    /// <example> 
    /// <code>
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// } </code><code><code><code>
    /// </code></code>
    /// 
    /// 
    /// 
    /// </code>
    /// <code>
    /// 
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public class Class12
    {
    }

    /// <summary>
    /// valid header
    /// </summary>
    /// <example> 
    /// <code>
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// } </code><code lang="c#><code><code>
    /// </code></code>
    /// 
    /// 
    /// 
    /// </code>
    /// <code>
    /// 
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// 
    /// 
    /// 
    /// </code>
    /// </example>
    public class Class13
    {
    }

    /// <summary>
    /// invalid header
    /// </summary>
    /// <example> 
    /// <![CDATA[
    /// public class ClassA : ClassBase
    /// {
    /// public ClassA(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// } </code><code><code><code>
    /// </code></code>
    /// 
    /// 
    /// 
    /// </code>
    /// <code>
    /// 
    /// public class ClassB : ClassBase
    /// {
    /// public ClassB(int identifier)
    /// : base(identifier)
    /// {
    /// }
    /// }
    /// ]]>
    /// 
    /// 
    /// 
    /// </example>
    public class Class14
    {
    }
}
namespace StyleCop.CSharpParserTest.TestData.Elements
{
    using System;

#if A 
	public class PreProcessorDirectives : ContextBoundObject, IPerfFoo
#elif B
	public class PreProcessorDirectives : IPerfFoo
#else
    public class PreProcessorDirectives : Object
#endif
    {
    }
}



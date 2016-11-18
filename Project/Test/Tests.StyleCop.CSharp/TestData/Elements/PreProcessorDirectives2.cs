#if DEBUG_FILTER
private void Repro()
{
#if !DEBUG
this is not seen here
#else
this is not seen either
#endif
}
#endif

namespace StyleCop.CSharpParserTest.TestData.Elements
{
    class PreProcessorDirectives2
    {
    }
}

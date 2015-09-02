namespace CSharpAnalyzersTest.TestData.Spacing
{
    class CloseSquareBracket
    {
        public class Class1
        {
            private string[]x; // invalid

            private string[] y; // valid
        }
    }
}

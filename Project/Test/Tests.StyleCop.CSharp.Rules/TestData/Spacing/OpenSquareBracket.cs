namespace CSharpAnalyzersTest.TestData.Spacing
{
    class OpenSquareBracket
    {
        public class Class1
        {
            private string [] x; // invalid

            private string[] y; // valid
        }
    }
}

namespace CSharpAnalyzersTest.TestData.Comments
{
    //Bad comment
    //  This is fine as it directly follows another single comment line

    internal class CommentsBeginWithSingleSpace
    {
        //Bad comment
        //  This is fine as it directly follows another single comment line
        private void MethodName()
        {
            //Bad comment
            //  This is fine as it directly follows another single comment line
        }
    }

    // ok
    // ok

    internal class CommentsBeginWithSingleSpace
    {
        // ok
        private void MethodName()
        {
            // ok 
        }
    }
}
namespace CSharpAnalyzersTest.TestData.Comments
{
    //Uh oh
    //  Uh oh

    internal class CommentsBeginWithSingleSpace
    {
        //Uh oh
        //  Uh oh
        private void MethodName()
        {
            //Uh oh
            //  Uh oh
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
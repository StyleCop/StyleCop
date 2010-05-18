using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CommentsMustContainText
    {
        public void ValidComments()
        {
            // This comment is ok since it contains text.

            // This comment is ok.
            //
            // Since the empty comment is surrounded by comments containing text.

            //.

            /* This is ok */

            /*
             this is ok too
             */

            /*
             
             also this
             
             */

            /* ok
             */

            /*
             ok */

// This is ok.

/* This is ok too */

/* 

This is ok
 */
        }

        public void InvalidComments()
        {
            //

            //
            // Not ok since the empty comment is at the top.

            // Not ok since the empty comment is at the bottom.
            //

            /* */

            /*
             */

            /*
             
             */

//

/* */

/*
*/

/*
 */
        }
    }
}

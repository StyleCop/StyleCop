namespace MethodDeclarationParameterFollowsComma1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region Normal Methods

    public class NormalMethods1
    {
        // Invalid placement
        public void Method8(int x,
            
            int y)
        {
        }

        public void Method9(
            int x, 
            
            int y)
        {
        }
        public void Method10(
            int x,


            int y)
        {
        }

        public void Method11(
            int x,
            int y,
            
            int z)
        {
        }

        public void Method12(
            int x,
            int y,
            

            int z)
        {
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Invalid placement
        public void Method10(
            [System.Runtime.InteropServices.In]int x, 
            
            [System.Runtime.InteropServices.In] int y)
        {
        }

        public void Method11(
            [System.Runtime.InteropServices.In]int x,

            [System.Runtime.InteropServices.In] int y,
            [System.Runtime.InteropServices.In] int z)
        {
        }

        // Invalid placement
        public void Method12(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In] int y,

            [System.Runtime.InteropServices.In] int z)
        {
        }


        // Invalid placement
        public void Method13(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In] int y,


            [System.Runtime.InteropServices.In] int z)
        {
        }


        // Invalid placement
        public void Method14(
            [System.Runtime.InteropServices.In]
            int x,

            [System.Runtime.InteropServices.In] 
            int y)
        {
        }

        public void Method15(
            [System.Runtime.InteropServices.In]
            int x,


            [System.Runtime.InteropServices.In] 
            int y)
        {
        }

        public void Method16(
            [System.Runtime.InteropServices.In]
            int x,
            [System.Runtime.InteropServices.In] 
            int y,
    
            [System.Runtime.InteropServices.In] 
            int z)
        {
        }

        public void Method17(
            [System.Runtime.InteropServices.In]
            int x,
            
            [System.Runtime.InteropServices.In] 
            int y,

            [System.Runtime.InteropServices.In] 
            int z)
        {
        }

        public void Method18(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x,

            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method19(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 

            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method20(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]

            int y)
        {
        }

        public void Method21(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out] int x,

            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out] int y)
        {
        }

        public void Method22(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In] 

            [System.Runtime.InteropServices.Out] int y)
        {
        }

        public void Method23(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,

            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method24(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            
            int y)
        {
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments1
    {
        // Invalid placement
        public void Method1(
            /*This is a comment*/int x,

            /*This is a comment*/ int y)
        {
        }

        public void Method2(
            /*This is a comment*/int x,

            /*This is a comment*/ int y,
            /*This is a comment*/ int z)
        {
        }

        public void Method3(
            /*This is a comment*/int x,
            /*This is a comment*/ int y,


            /*This is a comment*/ int z)
        {
        }


        public void Method4(
            // This is a comment
            /*This is a comment*/
            int x,

            /*This is a comment*/
            // This is a comment
            int y)
        {
        }

        public void Method5(
            /*This is a comment*/
            // This is a comment
            int x,


            // This is a comment
            /*This is a comment*/
            int y)
        {
        }

        public void Method6(
            /*This is a comment*/
            // This is a comment
            int x,
            /*This is a comment*/
            // This is a comment
            int y,

            // This is a comment
            /*This is a comment*/
            int z)
        {
        }

        public void Method7(
            /*This is a comment*/
            // This is a comment
            int x,

            // This is a comment
            /*This is a comment*/
            int y,

            /*This is a comment*/
            // This is a comment
            int z)
        {
        }

        public void Method8(
            /*This is a 
             * comment*/
            // This is a comment
            int x,

            // This is a comment
            /*This is a 
             * comment*/
            int y)
        {
        }

        public void Method9(
            /*This is a 
             * comment*/
            // This is a comment
            int x,
            /*This is a comment*/

            /*This is a comment*/
            // This is a comment
            int y)
        {
        }

        public void Method10(
            /*This is a 
             * comment*/
            // This is a comment
            int x,
            // This is a comment
            /*This is a 
             * comment*/

            int y)
        {
        }

        public void Method11(
            // This is a comment
            /*This is a 
             * comment*/ int x,

            // This is a comment
            /*This is a 
             * comment*/ int y)
        {
        }

        public void Method12(
            // This is a comment
            /*This is a 
             * comment*/ int x,
            // This is a comment
            /*This is a comment*/

            /*This is a 
             * comment*/ int y)
        {
        }
    }

    #endregion Comments

    #region Comments And Assembly Tags

    public class CommentsAndAssemblyTags1
    {
        // Invalid placement
        public void Method1(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a comment*/
            int x,

            /*This is a comment*/
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method2(
            /*This is a comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int x,


            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            /*This is a comment*/
            int y)
        {
        }

        public void Method3(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a comment*/
            // This is a comment
            int x,
            /*This is a comment*/
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int y,

           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a comment*/
            int z)
        {
        }

        public void Method4(
            /*This is a comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int x,

            // This is a comment
            /*This is a comment*/
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int y,

           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            /*This is a comment*/
            // This is a comment
            int z)
        {
        }

        public void Method5(
            /*This is a 
             * comment*/
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,

           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a 
             * comment*/
            int y)
        {
        }

        public void Method6(
            /*This is a 
             * comment*/
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            /*This is a comment*/

            /*This is a comment*/
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method7(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a 
             * comment*/
            // This is a comment
            int x,
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            /*This is a 
             * comment*/

            int y)
        {
        }

        public void Method8(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a 
             * comment*/
                         int x,

            // This is a comment
            /*This is a 
             * comment*/
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
                         int y)
        {
        }

        public void Method9(
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a 
             * comment*/
                         int x,
            // This is a comment
            /*This is a comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]

            /*This is a 
             * comment*/
                         int y)
        {
        }
    }


    public class Class71
    {
        private void MyMethod(int a, int b, int c, int d)
        {
        }

        private void Method2()
        {
            // valid
            MyMethod(
                1,
                2,
                3,
                4);

            // valid
            MyMethod(
                1,
                2,
                // foo
                3,
                4);

            // valid
            MyMethod(
                1,
                2,
                /* foo */
                3,
                4);

            // valid
            MyMethod(
                1,
                2, // bar
                /* foo */
                3,
                4);
        }
    }

    #endregion Comments And Assembly Tags
}

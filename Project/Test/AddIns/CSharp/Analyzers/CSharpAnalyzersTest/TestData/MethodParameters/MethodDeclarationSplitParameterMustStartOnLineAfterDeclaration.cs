namespace MethodDeclarationSplitParameterMustStartOnLineAfterDeclaration1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region Normal Methods
    
    public class NormalMethods1
    {
        // Invalid placement.
        public void Method1(int x,
            int y)
        {
        }

        public void Method2(int x,
            int y, int z)
        {
        }

        public void Method3(int x,
            int y,
            int z)
        {
        }

        public void Method4(int x, int y,
            int z)
        {
        }

        public void Method5(int x, int y,
            int z, int a)
        {
        }

        public void Method6(int x, int y,
            int z, 
            int a)
        {
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        public void Method1(int x,
            [System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In]
            int y)
        { 
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int y)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]
            int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method1([System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }



        public void Method1(int x,
            [System.Runtime.InteropServices.In]int y, [System.Runtime.InteropServices.In]int z)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In]
            int y,
            [System.Runtime.InteropServices.In]
            int z)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int y,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int z)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]
            int y,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int y,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method1(int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method1(int x, [System.Runtime.InteropServices.In]int y,
            [System.Runtime.InteropServices.In]int z)
        {
        }

        public void Method1(int x, [System.Runtime.InteropServices.In]int y,
            [System.Runtime.InteropServices.In]
            int z)
        {
        }

        public void Method1(int x, [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int y,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int z)
        {
        }

        public void Method1(int x, [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]int y,
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method1(int x, [System.Runtime.InteropServices.In] int y,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method1(int x, int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int z)
        {
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments1
    {
        public void Method1(int x,
            /*This is a comment*/int y)
        {
        }

        public void Method2(int x,
            // This is a comment
            /*This is a comment*/
            int y)
        {
        }

        public void Method3(int x,
            /*This is a 
             * comment*/
            // This is a comment
            int y)
        {
        }

        public void Method4(/*This is a comment*/int x,
            /*This is a comment*/int y)
        {
        }

        public void Method5(/*This is a comment*/int x,
            /*This is a comment*/
            // This is a comment
            int y)
        {
        }

        public void Method6(/*This is a comment*/int x,
            // This is a comment
            /*This is a 
             * comment*/
            int y)
        {
        }

        public void Method7(int x,
            /*This is a comment*/int y, /*This is a comment*/int z)
        {
        }

        public void Method8(int x,
            /*This is a comment*/
            // This is a comment
            int y,
            /*This is a comment*/
            // This is a comment
            int z)
        {
        }

        public void Method9(int x,
            // This is a comment
            /*This is a 
             * comment*/
            int y,
            // This is a comment
            /*This is a 
             * comment*/
            int z)
        {
        }

        public void Method10(int x, /*This is a comment*/int y,
            /*This is a comment*/int z)
        {
        }

        public void Method11(int x, /*This is a comment*/int y,
            // This is a comment
            /*This is a comment*/
            int z)
        {
        }

        public void Method12(int x, /*This is a comment*/ int y,
            /*This is a 
             * comment*/
            // This is a comment
            int z)
        {
        }
    }

    #endregion Comments

    #region Comments And Assembly Tags

    public class CommentsAndAssemblyTags1
    {
        public void Method1(int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a comment*/
            int y)
        {
        }

        public void Method2(int x,
            /*This is a 
             * comment*/
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method3(/*This is a comment*/int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a comment*/
            // This is a comment
            int y)
        {
        }

        public void Method4(/*This is a comment*/int x,
            // This is a comment
            /*This is a 
             * comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method5(int x,
            /*This is a comment*/
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y,
            /*This is a comment*/
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method6(int x,
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a 
             * comment*/
            int y,
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a 
             * comment*/
            int z)
        {
        }

        public void Method7(int x, /*This is a comment*/int y,
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a comment*/
            int z)
        {
        }

        public void Method8(int x, /*This is a comment*/ int y,
            /*This is a 
             * comment*/
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int z)
        {
        }
    }

    #endregion Comments And Assembly Tags
}

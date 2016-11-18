namespace MethodDeclarationSpanningMultipleLines1
{
    using System;

    #region Normal Methods

    public class NormalMethods1
    {
        // Invalid placement.
        public void Method1(int x, int 
            y)
        {
        }

        public void Method2(int x, out int
            y)
        {
        }

        public void Method3(int x, out 
            int y)
        {
        }

        public void Method4(
            int x, 
            int
            y)
        {
        }

        public void Method5(
            int x, 
            out int
            y)
        {
        }

        public void Method6(
            int x, 
            out 
            int y)
        {
        }

        public void Method7(int x, int y, int
            z)
        {
        }

        public void Method8(int x, int y, out int
            z)
        {
        }

        public void Method9(int x, int y, out 
            int z)
        {
        }

        public void Method10(
            int x, 
            int y, 
            int
            z)
        {
        }

        public void Method11(
            int x, 
            int y, 
            out int
            z)
        {
        }

        public void Method12(
            int x, 
            int y, 
            out 
            int z)
        {
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Invalid placement.
        public void Method1(int x, [System.Runtime.InteropServices.In]int
            y)
        {
        }

        public void Method2(int x, [System.Runtime.InteropServices.In]
            int
            y)
        {
        }

        public void Method3(
            int x, 
            [System.Runtime.InteropServices.In]int
            y)
        {
        }

        public void Method4(
            int x, 
            [System.Runtime.InteropServices.In]
            int
            y)
        {
        }

        public void Method5(
            int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int
            y)
        {
        }

        public void Method6(
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int
            y)
        {
        }

        public void Method7(int x, [System.Runtime.InteropServices.In]out int
            y)
        {
        }

        public void Method8(int x, [System.Runtime.InteropServices.In]
            out int
            y)
        {
        }

        public void Method9(
            int x, 
            [System.Runtime.InteropServices.In]out int
            y)
        {
        }

        public void Method10(
            int x, 
            [System.Runtime.InteropServices.In]
            out int
            y)
        {
        }

        public void Method11(
            int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out int
            y)
        {
        }

        public void Method12(
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out int
            y)
        {
        }

        public void Method13(int x, [System.Runtime.InteropServices.In]out 
            int y)
        {
        }

        public void Method14(int x, [System.Runtime.InteropServices.In]
            out 
            int y)
        {
        }

        public void Method15(
            int x, 
            [System.Runtime.InteropServices.In]out 
            int y)
        {
        }

        public void Method16(
            int x, 
            [System.Runtime.InteropServices.In]
            out 
            int y)
        {
        }

        public void Method17(
            int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out 
            int y)
        {
        }

        public void Method18(
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out 
            int y)
        {
        }

        public void Method19(int x, int y, [System.Runtime.InteropServices.In]int
            z)
        {
        }

        public void Method20(int x, int y, [System.Runtime.InteropServices.In]
            int
            z)
        {
        }

        public void Method21(
            int x,
            int y,
            [System.Runtime.InteropServices.In]int
            z)
        {
        }

        public void Method22(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            int
            z)
        {
        }

        public void Method23(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int
            z)
        {
        }

        public void Method24(
            int x,
            int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int
            z)
        {
        }

        public void Method25(int x, int y, [System.Runtime.InteropServices.In]out int
            z)
        {
        }

        public void Method26(int x, int y, [System.Runtime.InteropServices.In]
            out int
            z)
        {
        }

        public void Method27(
            int x,
            int y,
            [System.Runtime.InteropServices.In]out int
            z)
        {
        }

        public void Method28(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            out int
            z)
        {
        }

        public void Method29(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out int
            z)
        {
        }

        public void Method30(
            int x,
            int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out int
            z)
        {
        }

        public void Method31(int x, int y, [System.Runtime.InteropServices.In]out 
            int z)
        {
        }

        public void Method32(int x, int y, [System.Runtime.InteropServices.In]
            out 
            int z)
        {
        }

        public void Method33(
            int x,
            int y,
            [System.Runtime.InteropServices.In]out 
            int z)
        {
        }

        public void Method34(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            out 
            int z)
        {
        }

        public void Method35(
            int x,
            int y,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out 
            int z)
        {
        }

        public void Method36(
            int x,
            int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out 
            int z)
        {
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments1
    {
        // Invalid placement.
        public void Method1(int x, /*This is a comment*/int
            y)
        {
        }

        public void Method2(int x, /*This is a comment*/
            int
            y)
        {
        }

        public void Method3(
            int x,
            /*This is a comment*/int
            y)
        {
        }

        public void Method4(
            int x,
            /*This is a comment*/
            // This is a comment
            int
            y)
        {
        }

        public void Method5(
            int x,
            // This is a comment
            /*This is a 
             * comment*/
            int
            y)
        {
        }

        public void Method6(int x, /*This is a comment*/out int
            y)
        {
        }

        public void Method7(int x, /*This is a comment*/
            out int
            y)
        {
        }

        public void Method8(
            int x,
            /*This is a comment*/out int
            y)
        {
        }

        public void Method9(
            int x,
            // This is a comment
            /*This is a comment*/
            out int
            y)
        {
        }

        public void Method10(
            int x,
            /*This is a 
             * comment*/
            // This is a comment
            out int
            y)
        {
        }

        public void Method11(int x, /*This is a comment*/out 
            int y)
        {
        }

        public void Method12(int x, /*This is a comment*/
            out 
            int y)
        {
        }

        public void Method13(
            int x,
            // This is a comment
            /*This is a comment*/out 
            int y)
        {
        }

        public void Method14(
            int x,
            /*This is a comment*/
            // This is a comment
            out 
            int y)
        {
        }

        public void Method15(
            int x,
            /*This is a 
             * comment*/
            // This is a comment
            out 
            int y)
        {
        }
    }

    #endregion Comments

    #region CommentsAndAssemblyTags

    public class CommentsAndAssemblyTags1
    {
        // Invalid placement.
        public void Method1(
            int x,
            /*This is a comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int
            y)
        {
        }

        public void Method2(
            int x,
            // This is a comment
            /*This is a 
             * comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int
            y)
        {
        }

        public void Method3(
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            /*This is a comment*/
            out int
            y)
        {
        }

        public void Method4(
            int x,
            /*This is a 
             * comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            out int
            y)
        {
        }

        public void Method5(
            int x,
            // This is a comment
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a comment*/out 
            int y)
        {
        }

        public void Method6(
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /*This is a comment*/
            // This is a comment
            out 
            int y)
        {
        }

        public void Method7(
            int x,
            /*This is a 
             * comment*/
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            out 
            int y)
        {
        }

        public void Method8(
            int x,
            int y /*
                 */)
        {
        }
    }

    #endregion CommentsAndAssemblyTags
}

namespace MethodDeclarationValidPlacement1
{
    using System;

    #region known error

    public class KnownError
    {
        // create one error. The test will check to make sure that this is the only
        // violation seen within this file.
        public void Method1(
            )
        {
        }
    }

    #endregion known error

    #region Normal Methods
    
    public class NormalMethods1
    {
        // Valid placement
        public void Method1()
        {
        }

        public void Method2(int x)
        {
        }

        public void Method3(
            int x)
        {
        }

        public void Method4(int x, int y)
        {
        }

        public void Method5(int x,int y)
        {
        }

        public void Method6(int x,  int y)
        {
        }

        public void Method7(
            int x, int y)
        {
        }

        public void Method8(
            int x,int y)
        {
        }

        public void Method9(
            int x,
            int y)
        {
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public void Method10(int
            x)
        {
        }

        public void Method11(out int
            x)
        {
        }

        public void Method12(out 
            int x)
        {
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Valid placement
        public void Method1([System.Runtime.InteropServices.In]int x)
        {
        }

        public void Method2(
            [System.Runtime.InteropServices.In]int x)
        {
        }

        public void Method3(
            [System.Runtime.InteropServices.In]
            int x)
        {
        }

        public void Method4([System.Runtime.InteropServices.In] int x, [System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method5([System.Runtime.InteropServices.In]int x,[System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method6(
            [System.Runtime.InteropServices.In]int x, [System.Runtime.InteropServices.In] int y)
        {
        }

        public void Method7(
            [System.Runtime.InteropServices.In]int x,[System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method8(
            [System.Runtime.InteropServices.In] int x,
            [System.Runtime.InteropServices.In] int y)
        {
        }

        public void Method9(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]  int y)
        {
        }

        public void Method10(
            [System.Runtime.InteropServices.In] 
            int x,
            [System.Runtime.InteropServices.In] 
            int y)
        {
        }

        public void Method11(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]int y,
            [System.Runtime.InteropServices.In]int y)
        {
        }

        public void Method12(
            [System.Runtime.InteropServices.In]
            int x,
            [System.Runtime.InteropServices.In]
            int y,
            [System.Runtime.InteropServices.In]
            int z)
        {
        }

        public void Method13(
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In] int y)
        {
        }

        public void Method14(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]     int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]     int y)
        {
        }

        public void Method15(
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method16(
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int y,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int z)
        {
        }

        public void Method17(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public void Method18([System.Runtime.InteropServices.In]int
            x)
        {
        }

        public void Method19([System.Runtime.InteropServices.In]
            int
            x)
        {
        }

        public void Method20(
            [System.Runtime.InteropServices.In]int
            x)
        {
        }

        public void Method21(
            [System.Runtime.InteropServices.In]
            int
            x)
        {
        }

        public void Method22(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int
            x)
        {
        }

        public void Method23(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int
            x)
        {
        }

        public void Method24([System.Runtime.InteropServices.In]out int
            x)
        {
        }

        public void Method25([System.Runtime.InteropServices.In]
            out int
            x)
        {
        }

        public void Method26(
            [System.Runtime.InteropServices.In]out int
            x)
        {
        }

        public void Method27(
            [System.Runtime.InteropServices.In]
            out int
            x)
        {
        }

        public void Method28(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out int
            x)
        {
        }

        public void Method29(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out int
            x)
        {
        }

        public void Method30([System.Runtime.InteropServices.In]out 
            int x)
        {
        }

        public void Method31([System.Runtime.InteropServices.In]
            out 
            int x)
        {
        }

        public void Method32(
            [System.Runtime.InteropServices.In]out 
            int x)
        {
        }

        public void Method33(
            [System.Runtime.InteropServices.In]
            out 
            int x)
        {
        }

        public void Method34(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out 
            int x)
        {
        }

        public void Method35(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out 
            int x)
        {
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments
    {
        public void Method1(/* */)
        {
        }

        public void Method2(/*
         */
           )
        {
        }

        public void Method3(
            int x /*
                   */)
        {
        }








        public void Method5(/* This is a comment */int x)
        {
        }

        public void Method6(
            /* This is a comment */int x)
        {
        }

        public void Method7(
            // This is a comment
            /* This is a comment */
            int x)
        {
        }

        public void Method8(/* This is a comment */ int x, /* This is a comment */int y)
        {
        }

        public void Method9(
            /* This is a comment */int x, /* This is a comment */ int y)
        {
        }

        public void Method10(
            /* This is a comment */ int x,
            /* This is a comment */ int y)
        {
        }

        public void Method11(
            /* This is a comment */
            // This is a comment
            int x,
            // This is a comment
            /* This is a comment */ 
            int y)
        {
        }

        public void Method12(
            /* This is a 
             * comment */     int x,
            /* This is a 
             * comment */     int y)
        {
        }

        public void Method13(
            // This is a comment
            /* This is a 
             * comment */
            int x,
            /* This is a 
             * comment */
            // This is a comment
            int y)
        {
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public void Method14(/* This is a comment */int
            x)
        {
        }

        public void Method15(/* This is a comment */
            int
            x)
        {
        }

        public void Method16(
            /* This is a comment */int
            x)
        {
        }

        public void Method17(
            /* This is a comment */
            int
            x)
        {
        }

        public void Method18(
            /* This is a 
             * comment */
            // This is a comment
            int
            x)
        {
        }

        public void Method19(/* This is a comment */out int
            x)
        {
        }

        public void Method20(/* This is a comment */
            out int
            x)
        {
        }

        public void Method21(
            /* This is a comment */out int
            x)
        {
        }

        public void Method22(
            // This is a comment
            /* This is a comment */
            out int
            x)
        {
        }

        public void Method23(
            /* This is a 
             * comment */
            // This is a comment
            out int
            x)
        {
        }

        public void Method24(
            /* This is a 
             * comment */
            // This is a comment
            out int
            x/*
              
              
              */)
        {
        }
    }

    #endregion Comments
}

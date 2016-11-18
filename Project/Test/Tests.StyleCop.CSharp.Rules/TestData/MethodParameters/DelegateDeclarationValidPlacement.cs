namespace DelegateDeclarationValidPlacement1
{
    using System;

    #region known error

    public class KnownError
    {
        // create one error. The test will check to make sure that this is the only
        // violation seen within this file.
        public delegate void Delegate1(
            );
    }

    #endregion known error

    #region Normal Delegates

    public class NormalDelegates1
    {
        // Valid placement
        public delegate void Delegate1();

        public delegate void Delegate2(int x);

        public delegate void Delegate3(
            int x);

        public delegate void Delegate4(int x, int y);

        public delegate void Delegate5(int x, int y);

        public delegate void Delegate6(int x, int y);

        public delegate void Delegate7(
            int x, int y);

        public delegate void Delegate8(
            int x,int y);

        public delegate void Delegate9(
            int x,
            int y);

        // These are valid because the first parameter is allowed to span multiple lines.
        public delegate void Delegate10(int
            x);

        public delegate void Delegate11(out int
            x);

        public delegate void Delegate12(out 
            int x);
    }

    #endregion Normal Delegates

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Valid placement
        public delegate void Delegate1([System.Runtime.InteropServices.In]int x);

        public delegate void Delegate2(
            [System.Runtime.InteropServices.In]int x);

        public delegate void Delegate3(
            [System.Runtime.InteropServices.In]
            int x);

        public delegate void Delegate4([System.Runtime.InteropServices.In] int x, [System.Runtime.InteropServices.In]int y);

        public delegate void Delegate5([System.Runtime.InteropServices.In]int x, [System.Runtime.InteropServices.In]int y);

        public delegate void Delegate6(
            [System.Runtime.InteropServices.In]int x, [System.Runtime.InteropServices.In] int y);

        public delegate void Delegate7(
            [System.Runtime.InteropServices.In]int x,[System.Runtime.InteropServices.In]int y);

        public delegate void Delegate8(
            [System.Runtime.InteropServices.In] int x,
            [System.Runtime.InteropServices.In] int y);

        public delegate void Delegate9(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]  int y);

        public delegate void Delegate10(
            [System.Runtime.InteropServices.In] 
            int x,
            [System.Runtime.InteropServices.In] 
            int y);

        public delegate void Delegate11(
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]int y,
            [System.Runtime.InteropServices.In]int y);

        public delegate void Delegate12(
            [System.Runtime.InteropServices.In]
            int x,
            [System.Runtime.InteropServices.In]
            int y,
            [System.Runtime.InteropServices.In]
            int z);

        public delegate void Delegate13(
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In] int y);

        public delegate void Delegate14(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]     int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]     int y);

        public delegate void Delegate15(
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int y);

        public delegate void Delegate16(
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int y,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int z);

        public delegate void Delegate17(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y);

        // These are valid because the first parameter is allowed to span multiple lines.
        public delegate void Delegate18([System.Runtime.InteropServices.In]int
            x);

        public delegate void Delegate19([System.Runtime.InteropServices.In]
            int
            x);

        public delegate void Delegate20(
            [System.Runtime.InteropServices.In]int
            x);

        public delegate void Delegate21(
            [System.Runtime.InteropServices.In]
            int
            x);

        public delegate void Delegate22(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int
            x);

        public delegate void Delegate23(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int
            x);

        public delegate void Delegate24([System.Runtime.InteropServices.In]out int
            x);

        public delegate void Delegate25([System.Runtime.InteropServices.In]
            out int
            x);

        public delegate void Delegate26(
            [System.Runtime.InteropServices.In]out int
            x);

        public delegate void Delegate27(
            [System.Runtime.InteropServices.In]
            out int
            x);

        public delegate void Delegate28(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out int
            x);

        public delegate void Delegate29(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out int
            x);

        public delegate void Delegate30([System.Runtime.InteropServices.In]out 
            int x);

        public delegate void Delegate31([System.Runtime.InteropServices.In]
            out 
            int x);

        public delegate void Delegate32(
            [System.Runtime.InteropServices.In]out 
            int x);

        public delegate void Delegate33(
            [System.Runtime.InteropServices.In]
            out 
            int x);

        public delegate void Delegate34(
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            out 
            int x);

        public delegate void Delegate35(
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            out 
            int x);
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments
    {
        public delegate void Delegate1(/* */);

        public delegate void Delegate2(/*
         */
           );

        public delegate void Delegate3(
            int x /*
                   */);

        public delegate void Delegate4(
            int x,
            int y /*
             */);

        public delegate void Delegate5(/* This is a comment */int x);

        public delegate void Delegate6(
            /* This is a comment */int x);

        public delegate void Delegate7(
            // This is a comment
            /* This is a comment */
            int x);

        public delegate void Delegate8(/* This is a comment */ int x, /* This is a comment */int y);

        public delegate void Delegate9(
            /* This is a comment */int x, /* This is a comment */ int y);

        public delegate void Delegate10(
            /* This is a comment */ int x,
            /* This is a comment */ int y);

        public delegate void Delegate11(
            /* This is a comment */
            // This is a comment
            int x,
            // This is a comment
            /* This is a comment */ 
            int y);

        public delegate void Delegate12(
            /* This is a 
             * comment */     int x,
            /* This is a 
             * comment */     int y);

        public delegate void Delegate13(
            // This is a comment
            /* This is a 
             * comment */
            int x,
            /* This is a 
             * comment */
            // This is a comment
            int y);

        // These are valid because the first parameter is allowed to span multiple lines.
        public delegate void Delegate14(/* This is a comment */int
            x);

        public delegate void Delegate15(/* This is a comment */
            int
            x);

        public delegate void Delegate16(
            /* This is a comment */int
            x);

        public delegate void Delegate17(
            /* This is a comment */
            int
            x);

        public delegate void Delegate18(
            /* This is a 
             * comment */
            // This is a comment
            int
            x);

        public delegate void Delegate19(/* This is a comment */out int
            x);

        public delegate void Delegate20(/* This is a comment */
            out int
            x);

        public delegate void Delegate21(
            /* This is a comment */out int
            x);

        public delegate void Delegate22(
            // This is a comment
            /* This is a comment */
            out int
            x);

        public delegate void Delegate23(
            /* This is a 
             * comment */
            // This is a comment
            out int
            x);

        public delegate void Delegate24(
            /* This is a 
             * comment */
            // This is a comment
            out int
            x/*
              
              
              */);
    }

    #endregion Comments
}

namespace IndexerDeclarationValidPlacement1
{
    using System;

    #region known error

    public class KnownError
    {
        // create one error. The test will check to make sure that this is the only
        // violation seen within this file.
        public bool this[int x
            ]
        {
            get { return true; }
        }
    }

    #endregion known error

    #region Normal Methods
    
    public class NormalMethods1
    {
        // Valid placement
        public bool this[int x]
        {
            get { return true; }
        }

        public bool this[
            short x]
        {
            get { return true; }
        }

        public bool this[int x, int y]
        {
            get { return true; }
        }

        public bool this[int x, short y]
        {
            get { return true; }
        }

        public bool this[int x, long y]
        {
            get { return true; }
        }

        public bool this[
            int x, float y]
        {
            get { return true; }
        }

        public bool this[
            int x,double y]
        {
            get { return true; }
        }

        public bool this[
            int x,
            object y]
        {
            get { return true; }
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public bool this[long
            x]
        {
            get { return true; }
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Valid placement
        public bool this[[System.Runtime.InteropServices.In]int x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]long x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]
            short x]
        {
            get { return true; }
        }

        public bool this[[System.Runtime.InteropServices.In] int x, [System.Runtime.InteropServices.In]int y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]int x,[System.Runtime.InteropServices.In]short y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In] int x,
            [System.Runtime.InteropServices.In] long y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In] 
            int x,
            [System.Runtime.InteropServices.In] 
            float y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]int x,
            [System.Runtime.InteropServices.In]int y,
            [System.Runtime.InteropServices.In]int y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]
            int x,
            [System.Runtime.InteropServices.In]
            int y,
            [System.Runtime.InteropServices.In]
            short z]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In][System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In] long y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]     int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]     double y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            object y]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            short y,
            [System.Runtime.InteropServices.In] 
            [System.Runtime.InteropServices.Out]
            int z]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            string y]
        {
            get { return true; }
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public bool this[[System.Runtime.InteropServices.In]string
            x]
        {
            get { return true; }
        }

        public bool this[[System.Runtime.InteropServices.In]
            DateTime
            x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]int[]
            x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]
            short[]
            x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int[,]
            x]
        {
            get { return true; }
        }

        public bool this[
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int[, ,]
            x]
        {
            get { return true; }
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments
    {
        public bool this[int x/* */]
        {
            get { return true; }
        }

        public bool this[short x/*
         */
           ]
        {
            get { return true; }
        }

        public bool this[
            long x /*
                   */
                     ]
        {
            get { return true; }
        }

        public bool this[
            int x,
            int y /*
             */
               ]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */float x]
        {
            get { return true; }
        }

        public bool this[
            // This is a comment
            /* This is a comment */
            double x]
        {
            get { return true; }
        }

        public bool this[/* This is a comment */ int x, /* This is a comment */long y]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */int x, /* This is a comment */ float y]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */ int x,
            /* This is a comment */ double y]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */
            // This is a comment
            int x,
            // This is a comment
            /* This is a comment */
            byte y]
        {
            get { return true; }
        }

        public bool this[
            /* This is a 
             * comment */
                              int x,
            /* This is a 
             * comment */
                              char y]
        {
            get { return true; }
        }

        public bool this[
            // This is a comment
            /* This is a 
             * comment */
            int x,
            /* This is a 
             * comment */
            // This is a comment
            int[,] y]
        {
            get { return true; }
        }

        // These are valid because the first parameter is allowed to span multiple lines.
        public bool this[/* This is a comment */string
            x]
        {
            get { return true; }
        }

        public bool this[/* This is a comment */
            object
            x]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */object[, ,]
            x]
        {
            get { return true; }
        }

        public bool this[
            /* This is a comment */
            string
            x]
        {
            get { return true; }
        }

        public bool this[
            /* This is a 
             * comment */
            // This is a comment
            byte
            x]
        {
            get { return true; }
        }
    }

    #endregion Comments
}

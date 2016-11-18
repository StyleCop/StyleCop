namespace MethodDeclarationOpeningParenthesisPlacement1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region Normal Methods

    public class NormalMethods1
    {
        // Invalid placement.
        public void Method4
            ()
        {
        }

        public void Method5
            (
            )
        {
        }

        public void Method6
            (int x)
        {
        }

        public void Metohd7
            (
            int x)
        {
        }

        public void Method8

            (int x)
        {
        }
    }

    #endregion Normal Methods

    #region Assembly Tags

    public class AssemblyTags1
    {
        // Invalid placement.
        public void Method4
            ([System.Runtime.InteropServices.In]int x)
        {
        }

        public void Method5
            (
            [System.Runtime.InteropServices.In]int x)
        {
        }

        public void Method6
            (
            [System.Runtime.InteropServices.In]
            int x)
        {
        }

        public void Method7

            ([System.Runtime.InteropServices.In]int x)
        {
        }

        public void Method8
            (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x)
        {
        }

        public void Method9
            (
            [System.Runtime.InteropServices.In, 
             System.Runtime.InteropServices.Out]
            int x)
        {
        }

        public void Method10
        (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method11
            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method12
            (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]int y)
        {
        }

        public void Method13
            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]int y)
        {
        }

        public void Method14
    
            (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x)
        {
        }

        public void Method15
            
            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x)
        {
        }

        public void Method16
        
            (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method17
            
            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method18
            
            (
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out] int x,
            [System.Runtime.InteropServices.In]
            [System.Runtime.InteropServices.Out]int y)
        {
        }

        public void Method19

            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]int x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]int y)
        {
        }
    }

    #endregion Assembly Tags

    #region Comments

    public class Comments1
    {
        // Invalid placement.
        public void Method1
            (/* This is comment */int x)
        {
        }

        public void Method2
            (
            /* This is comment */int x)
        {
        }

        public void Method3
            (
            // This is a comment
            /* This is comment */
            int x)
        {
        }

        public void Method4

            (/* This is comment */int x)
        {
        }

        public void Method5
            (
            /* This is 
             * comment */
            // This is a comment
            int x)
        {
        }

        public void Method6
        (
            /* This is 
             * comment */
            // This is a comment
            int x,
            // This is a comment
            /* This is 
             * comment */
            int y)
        {
        }

        public void Method7
            (
            /* This is 
             * comment */
            // This is a comment
            int x,
            // This is a comment
            /* This is 
             * comment */
            int y)
        {
        }

        public void Method8
            (
            /* This is 
            // This is a comment
             * comment */
              int x,
            // This is a comment
            /* This is 
             * comment */
             int y)
        {
        }

        public void Method9

            (
            /* This is 
             * comment */
            // This is a comment
            int x)
        {
        }
    }

    #endregion Comments

    #region Comments And Assembly Tags

    public class CommentsAndAssemblyTags1
    {
        // Invalid placement.
        public void Method1
            (
            // This is a comment
            /* This is comment */
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int x)
        {
        }

        public void Method2
            (
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            /* This is 
             * comment */
            // This is a comment
            int x)
        {
        }

        public void Method3
        (
            /* This is 
             * comment */
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int x,
            // This is a comment
            /* This is 
             * comment */
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            int y)
        {
        }

        public void Method4
            (
            /* This is 
             * comment */
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int x,
            // This is a comment
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            /* This is 
             * comment */
            int y)
        {
        }

        public void Method5
            (
            /* This is 
            // This is a comment
             * comment */
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
              int x,
           [System.Runtime.InteropServices.In,
            System.Runtime.InteropServices.Out]
            // This is a comment
            /* This is 
             * comment */
             int y)
        {
        }

        public void Method6

            (
            /* This is 
             * comment */
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            // This is a comment
            int x)
        {
        }
    }

    #endregion Comments And Assembly Tags
}

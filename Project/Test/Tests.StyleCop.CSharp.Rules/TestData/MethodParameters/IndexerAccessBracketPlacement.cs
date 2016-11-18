namespace CSharpAnalyzersTest.TestData.IndexerAccessBracketPlacement
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Test code for SA1110 rule - opening paren must be on declaration line.
    /// </summary>
    public class SA1110TestCode
    {
        private int this
            [int x]
        {
            get
            {
                return this
                    [x];
            }
        }

        private string JoinStrings
            (string first, string last)
        {
            return this.JoinStrings
                (first, last);
        }
    }

    public class SA1111TestCode
    {
        private int this[int x
            ]
        {
            get
            {
                return this[x
                    ];
            }
        }

        private string JoinStrings(string first, string last
            )
        {
            return this.JoinStrings(first, last
                );
        }
    }

    public class SA1113TestCode
    {
        private int this[int x
            , int y]
        {
            get
            {
                return this[x
                    , y];
            }
        }

        private string JoinStrings(
            string first
            , string last)
        {
            return this.JoinStrings(
                first
                , last);
        }
    }

    /// <summary>
    /// Test code for SA1114 rule - parameters must be on the same or on the next line as opening paren.
    /// </summary>
    public class SA1114TestCode
    {
        private int this[

            int x]
        {
            get
            {
                return this[

                    x];
            }
        }

        private string JoinStrings(

            string first)
        {
            return this.JoinStrings(

                first);
        }
    }

    /// <summary>
    /// Test code for SA1115 rule - parameter must be on the same or on the next line as previous parameter.
    /// </summary>
    public class SA1115TestCode
    {
        private int this[
            int x,

            int y]
        {
            get
            {
                return this[
                    x,

                    y];
            }
        }

        private string JoinStrings(
            string first,

            string last)
        {
            return this.JoinStrings(
                first,

                last);
        }
    }

    /// <summary>
    /// Test code for SA1116 rule - split parameters must begin on line after declaration.
    /// </summary>
    public class SA1116TestCode
    {
        private int this[int x,
            int y]
        {
            get
            {
                return this[x,
                    y];
            }
        }

        private string JoinStrings(string first,
            string last)
        {
            return this.JoinStrings(first,
                last);
        }
    }

    /// <summary>
    /// Test code for SA1117 rule - parameters must be on the same line or on separate lines each.
    /// </summary>
    public class SA1117TestCode
    {
        private int this[
            int x, int y,
            int z]
        {
            get
            {
                return this[
                    x, y,
                    z];
            }
        }

        private string JoinStrings(
            string x, string y,
            string z)
        {
            return this.JoinStrings(
                x, y,
                z);
        }
    }

    /// <summary>
    /// Test code for SA1118 rule - only first parameter can span multiple lines.
    /// </summary>
    public class SA1118TestCode
    {
        private int this[
            int x,
            int
            y]
        {
            get
            {
                return this[
                    x,
                    y
                    + y];
            }
        }

        private string JoinStrings(
            string x,
            string
            y)
        {
            return this.JoinStrings(
                x,
                y
                + y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class DocumentationIndexers
    {
        /// <summary>
        /// Gets a value indicating whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public bool this[int x]
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public Dictionary<int[], bool?> this[short x]
        {
            get { return null; }
        }

        /// <summary>
        /// Sets a whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public Dictionary<int[], bool?> this[long x]
        {
            set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public Dictionary<int[], bool?> this[float x]
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public Dictionary<int[], bool?> this[double x]
        {
            get { return null; }
            internal set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        internal Dictionary<int[], bool?> this[string x]
        {
            get { return null; }
            protected set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        protected Dictionary<int[], bool?> this[object x]
        {
            get { return null; }
            private set { }
        }

        /// <summary>
        /// Gets the whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        protected internal Dictionary<int[], bool?> this[char x]
        {
            get { return null; }
            private set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        private Dictionary<int[], bool?> this[byte x]
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Gets or sets a whatever.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        public Dictionary<int[], bool?> this[DateTime x]
        {
            get { return null; }
            set { }
        }

        /// <summary>Gets or sets a whatever.</summary><value>This is the value.</value><param name="x">This is the parameter.</param>
        public int this [bool x]
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the parameter.</param>
        /// <remarks>Adding a remarks tag.</remarks>
        public string this[int[] x]
        {
            get { return null; }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        public string this[int x, int y, int z]
        {
            get { return null; }
        }

        /// <summary>
        /// Some of the text is repeated.
        /// </summary>
        /// <param name="x">The parameter is not used.</param>
        /// <param name="y">The parameter is not used.</param>
        /// <param name="z">The parameter is not used.</param>
        public string this[bool x, bool y, bool z]
        {
            get { return null; }
        }

        /// <summary>
        /// Summary description for property.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[short[] x]
        {
            get { return 1; }
        }

        /// The property's xml is invalid. Missing opening summary tag.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[long[] x]
        {
            get { return 1; }
        }

        public int this[float[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[double[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[char[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Short.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[byte[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[object[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// gets no capital letter.
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[string[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets no closing period
        /// </summary>
        /// <param name="x">This is a parameter.</param>
        public int this[DateTime[] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        public int this[int[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x"></param>
        public int this[short[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x">Nospaceshereatall.</param>
        public int this[long[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x">Short.</param>
        public int this[float[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x">B-03q4-340-82340-572-3759827345972349057295729034579234892347958not enough letters.</param>
        public int this[double[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x">no capital letter.</param>
        public int this[char[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Gets a whatever.
        /// </summary>
        /// <param name="x">No closing period</param>
        public int this[byte[][] x]
        {
            get { return 1; }
        }

        /// <summary>
        /// Line that is copied.
        /// </summary>
        /// <param name="x">Line that is copied.</param>
        /// <param name="y">This is whatever.</param>
        public int this[byte x, byte y]
        {
            get { return 1; }
        }

        /// <summary>
        /// Line that is copied.
        /// </summary>
        /// <param name="x">This is whatever.</param>
        /// <param name="y">Line that is copied.</param>
        public int this[char x, char y]
        {
            get { return 1; }
        }

        /// <summary>
        /// This is a summary.
        /// </summary>
        /// <param name="x">Line that is copied.</param>
        /// <param name="y">Line that is copied.</param>
        public int this[float x, float y]
        {
            get { return 1; }
        }

        /// <summary>
        /// The params are in the wrong order.
        /// </summary>
        /// <param name="y">This is the second param.</param>
        /// <param name="x">This is the first param.</param>
        public int this[double x, double y]
        {
            get { return 1; }
        }

        internal int this[int x, short y]
        {
            get { return 1; }
        }

        protected int this[int x, long y]
        {
            get { return 1; }
        }

        protected internal int this[int x, float y]
        {
            get { return 1; }
        }

        private int this[int x, double y]
        {
            get { return 1; }
        }

        public int this[int x, char y]
        {
            get { return 1; }
        }

        /// <summary>
        /// Omits the get wording.
        /// </summary>
        public int this[int x, byte y]
        {
            get { return 1; }
        }
        
        /// <summary>
        /// Omits the set wording.
        /// </summary>
        public int this[int x, bool y]
        {
            set { }
        }

        /// <summary>
        /// Omits the get and set wording.
        /// </summary>
        public int this[int x, string y]
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Gets the (omits the set wording).
        /// </summary>
        public int this[int x, object y]
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Sets the (omits the get wording).
        /// </summary>
        public int this[int x, DateTime y]
        {
            get { return 1; }
            set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        public int this[short x, int y]
        {
            get { return 1; }
            internal set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        public int this[short x, long y]
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        internal int this[short x, char y]
        {
            get { return 1; }
            protected set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        protected int this[short x, byte y]
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// Gets or sets the (shouldn't use set wording since set accessor is internal).
        /// </summary>
        protected internal int this[short x, object y]
        {
            get { return 1; }
            private set { }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <remarks></remarks>
        public string this[short x, float y]
        {
            get { return null; }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter</param>
        /// <param name="z">The third parameter.</param>
        public string this[short x, DateTime y]
        {
            get { return null; }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param name="y">The second parameter</param>
        /// <param>The third parameter.</param>
        public string this[short x, bool y]
        {
            get { return null; }
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">The first parameter.</param>
        /// <param>The second parameter</param>
        public string this[short x, string y]
        {
            get { return null; }
        }

        /// <summary>
        /// This is the summary. Param tag is missing for Z.
        /// </summary>
        /// <param name="x">The first param.</param>
        /// <param name="y">The second param.</param>
        public string this[long x, short y, int z]
        {
        }
    }
}

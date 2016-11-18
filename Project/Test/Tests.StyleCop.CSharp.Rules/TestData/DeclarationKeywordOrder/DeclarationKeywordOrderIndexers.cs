using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderIndexers
    {
        // Valid indexers
        int this[int x]
        {
            get { return 0; }
        }

        public int this[short x]
        {
            get { return 0; }
        }

        internal int this[long x]
        {
            get { return 0; }
        }

        protected int this[float x]
        {
            get { return 0; }
        }

        protected int this[double x]
        {
            get { return 0; }
        }

        private int this[object x]
        {
            get { return 0; }
        }

        new int this[byte x]
        {
            get { return 0; }
        }

        public new int this[char x]
        {
            get { return 0; }
        }

        internal new int this[string x]
        {
            get { return 0; }
        }

        protected new int this[DateTime x]
        {
            get { return 0; }
        }

        protected internal new int this[List<int> x]
        {
            get { return 0; }
        }

        private new int this[List<short> x]
        {
            get { return 0; }
        }

        virtual int this[List<long> x]
        {
            get { return 0; }
        }

        public virtual int this[List<object> x]
        {
            get { return 0; }
        }

        internal virtual int this[List<float> x]
        {
            get { return 0; }
        }

        protected virtual int this[List<double> x]
        {
            get { return 0; }
        }

        protected internal int this[List<byte> x]
        {
            get { return 0; }
        }

        private virtual int this[List<char> x]
        {
            get { return 0; }
        }

        sealed int this[List<DateTime> x]
        {
            get { return 0; }
        }

        public sealed int this[int[] x]
        {
            get { return 0; }
        }

        internal sealed int this[short[] x]
        {
            get { return 0; }
        }

        protected sealed int this[long[] x]
        {
            get { return 0; }
        }

        protected internal int this[float[] x]
        {
            get { return 0; }
        }

        private sealed int this[double[] x]
        {
            get { return 0; }
        }

        override int this[object[] x]
        {
            get { return 0; }
        }

        public override int this[byte[] x]
        {
            get { return 0; }
        }

        internal override int this[char[] x]
        {
            get { return 0; }
        }

        protected override int this[string[] x]
        {
            get { return 0; }
        }

        protected internal int this[DateTime[] x]
        {
            get { return 0; }
        }

        private override int this[List<int[]> x]
        {
            get { return 0; }
        }

        abstract int this[List<short[]> x]
        {
            get { return 0; }
        }

        public abstract int this[List<long[]> x]
        {
            get { return 0; }
        }

        internal abstract int this[List<float[]> x]
        {
            get { return 0; }
        }

        protected abstract int this[List<double[]> x]
        {
            get { return 0; }
        }

        protected internal abstract int this[List<byte[]> x]
        {
            get { return 0; }
        }

        private abstract int this[List<char[]> x]
        {
            get { return 0; }
        }

        extern int this[List<string[]> x]
        {
            get { return 0; }
        }

        public extern int this[List<object[]> x]
        {
            get { return 0; }
        }

        internal extern int this[List<DateTime[]> x]
        {
            get { return 0; }
        }

        protected extern int this[int[][] x]
        {
            get { return 0; }
        }

        protected internal extern int this[short[][] x]
        {
            get { return 0; }
        }

        private extern int this[long[][] x]
        {
            get { return 0; }
        }

        new virtual override abstract extern int this[float[][] x]
        {
            get { return 0; }
        }

        public new virtual override abstract extern int this[double[][] x]
        {
            get { return 0; }
        }

        internal virtual new override abstract extern int this[char[][] x]
        {
            get { return 0; }
        }

        protected override virtual new abstract extern int this[byte[][] x]
        {
            get { return 0; }
        }

        protected internal abstract override virtual new extern int this[string[][] x]
        {
            get { return 0; }
        }

        private extern abstract override virtual new int this[object[][] x]
        {
            get { return 0; }
        }

        // Invalid indexers
        internal protected int this[int x, int y]
        {
            get { return 0; }
        }

        new public int this[int x, short y]
        {
            get { return 0; }
        }

        new internal int this[int x, long y]
        {
            get { return 0; }
        }

        new protected int this[int x, double y]
        {
            get { return 0; }
        }

        new protected internal int this[int x, float y]
        {
            get { return 0; }
        }

        new internal protected int this[int x, object y]
        {
            get { return 0; }
        }

        internal protected new int this[int x, char y]
        {
            get { return 0; }
        }

        protected new internal int this[int x, byte y]
        {
            get { return 0; }
        }

        internal new protected int this[int x, string y]
        {
            get { return 0; }
        }

        new private int this[int x, DateTime y]
        {
            get { return 0; }
        }

        virtual public int this[short x, int y]
        {
            get { return 0; }
        }

        virtual internal int this[short x, long y]
        {
            get { return 0; }
        }

        virtual protected int this[short x, short y]
        {
            get { return 0; }
        }

        virtual protected internal int this[short x, float y]
        {
            get { return 0; }
        }

        virtual internal protected int this[short x, double y]
        {
            get { return 0; }
        }

        internal protected virtual int this[short x, char y]
        {
            get { return 0; }
        }

        internal virtual protected int this[short x, byte y]
        {
            get { return 0; }
        }

        protected virtual internal int this[short x, object y]
        {
            get { return 0; }
        }

        virtual private int this[short x, string y]
        {
            get { return 0; }
        }

        sealed public int this[short x, DateTime y]
        {
            get { return 0; }
        }

        sealed internal int this[long x, int y]
        {
            get { return 0; }
        }

        sealed protected int this[long x, short y]
        {
            get { return 0; }
        }

        sealed protected internal int this[long x, long y]
        {
            get { return 0; }
        }

        sealed internal protected int this[long x, float y]
        {
            get { return 0; }
        }

        internal protected sealed int this[long x, double y]
        {
            get { return 0; }
        }

        internal sealed protected int this[long x, bool y]
        {
            get { return 0; }
        }

        protected sealed internal int this[long x, char y]
        {
            get { return 0; }
        }

        sealed private int this[long x, byte y]
        {
            get { return 0; }
        }

        override public int this[long x, object y]
        {
            get { return 0; }
        }

        override internal int this[long x, string y]
        {
            get { return 0; }
        }

        override protected int this[long x, DateTime y]
        {
            get { return 0; }
        }

        override protected internal int this[float x, int y]
        {
            get { return 0; }
        }

        override internal protected int this[float x, short y]
        {
            get { return 0; }
        }

        internal protected override int this[float x, long y]
        {
            get { return 0; }
        }

        internal override protected int this[float x, float y]
        {
            get { return 0; }
        }

        protected override internal int this[float x, double y]
        {
            get { return 0; }
        }

        override private int this[float x, bool y]
        {
            get { return 0; }
        }

        abstract public int this[float x, byte y]
        {
            get { return 0; }
        }

        abstract internal int this[float x, char y]
        {
            get { return 0; }
        }

        abstract protected int this[float x, object y]
        {
            get { return 0; }
        }

        abstract protected internal int this[float x, string y]
        {
            get { return 0; }
        }

        abstract internal protected int this[float x, DateTime y]
        {
            get { return 0; }
        }

        internal protected abstract int this[double x, int y]
        {
            get { return 0; }
        }

        internal abstract protected int this[double x, short y]
        {
            get { return 0; }
        }

        protected abstract internal int this[double x, long y]
        {
            get { return 0; }
        }

        abstract private int this[double x, float y]
        {
            get { return 0; }
        }

        extern public int this[double x, double y]
        {
            get { return 0; }
        }

        extern internal int this[double x, bool y]
        {
            get { return 0; }
        }

        extern protected int this[double x, byte y]
        {
            get { return 0; }
        }

        extern protected internal int this[double x, char y]
        {
            get { return 0; }
        }

        extern internal protected int this[double x, object y]
        {
            get { return 0; }
        }

        internal protected extern int this[double x, string y]
        {
            get { return 0; }
        }

        internal extern protected int this[double x, DateTime y]
        {
            get { return 0; }
        }

        protected extern internal int this[bool x, int y]
        {
            get { return 0; }
        }

        extern private int this[bool x, short y]
        {
            get { return 0; }
        }

        new virtual override abstract extern public int this[bool x, long y]
        {
            get { return 0; }
        }

        virtual new override abstract extern internal int this[bool x, float y]
        {
            get { return 0; }
        }

        override virtual new abstract extern protected int this[bool x, double y]
        {
            get { return 0; }
        }

        abstract override virtual new extern protected internal int this[bool x, bool y]
        {
            get { return 0; }
        }

        abstract override virtual new extern internal protected int this[bool x, char y]
        {
            get { return 0; }
        }

        internal protected abstract override virtual new extern int this[bool x, byte y]
        {
            get { return 0; }
        }

        internal virtual protected abstract override new extern int this[bool x, object y]
        {
            get { return 0; }
        }

        protected abstract override virtual internal new extern int this[bool x, string y]
        {
            get { return 0; }
        }

        internal virtual abstract override new extern protected int this[bool x, DateTime y]
        {
            get { return 0; }
        }

        protected abstract override virtual new extern internal int this[byte x, int y]
        {
            get { return 0; }
        }

        extern abstract override virtual new private int this[byte x, short y]
        {
            get { return 0; }
        }
    }
}

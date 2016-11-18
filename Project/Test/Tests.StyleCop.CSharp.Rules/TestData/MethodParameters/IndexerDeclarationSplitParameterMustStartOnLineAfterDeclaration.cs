namespace IndexerDeclarationSplitParameterMustStartOnLineAfterDeclaration1
{
    using System;

    public class NormalMethods1
    {
        public bool this[int x,
            int y]
        {
            get { return true; }
        }

        public bool this[int x,
            int y, int z]
        {
            get { return true; }
        }

        public bool this[short x,
            int[, ,] y,
            int z]
        {
            get { return true; }
        }

        public bool this[long x, int y,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int z]
        {
            get { return true; }
        }

        public bool this[float x, int y,
            int z, int a]
        {
            get { return true; }
        }

        public bool this[double x, int y,
            int z, 
            /* this is a 
             * comment */
            int[][] a]
        {
            get { return true; }
        }
    }
}

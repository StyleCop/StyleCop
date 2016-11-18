namespace IndexerDeclarationSpanningMultipleLines1
{
    using System;

    public class NormalMethods1
    {
        public bool this[int x, int 
            y]
        {
            get { return true; }
        }

        public bool this[
            /*comment
             * */
            short x, 
            int
            y]
        {
            get { return true; }
        }

        public bool this[long x, int y, int
            z]
        {
            get { return true; }
        }

        public bool this[
            double x,
            [System.Runtime.InteropServices.In,
             System.Runtime.InteropServices.Out]
            int[,] y, 
            int
            z]
        {
            get { return true; }
        }
    }
}

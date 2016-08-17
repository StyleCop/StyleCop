namespace IndexerDeclarationParameterListStart1
{
    using System;

    public class NormalMethods1
    {
        public bool this[

            int[, , ] x]
        {
            get { return true; }
        }

        public bool this[

            short x, int y]
        {
            get { return true; }
        }

        public bool this[

            long x,
            /* this is a comment 
             */
            // This too
            int y]
        {
            get { return true; }
        }

        public bool this[


            double x]
        {
            get { return true; }
        }
    }
}

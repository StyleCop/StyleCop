namespace IndexerDeclarationParameterFollowsComma1
{
    using System;

    public class NormalMethods1
    {
        public bool this[int[,] x,
            
            int[][] y]
        {
            get { return true; }
        }

        public bool this[
            /* this is a comment
             * */
            short x, 
            
            int y/*
                  * this is too*/]
        {
            get { return true; }
        }

        public bool this[
            long x/*
                   * this is allowed*/,


            int y]
        {
            get { return true; }
        }

        public bool this[
            bool x,
            int y,
            
            int z]
        {
            get { return true; }
        }

        public bool this[
            string x,
            int y,
            

            int z]
        {
            get { return true; }
        }
    }
}

namespace IndexerDeclarationCommaPlacement1
{
    using System;

    public class NormalMethods1
    {
        public bool this[int x
            , int y]
        {
            get { return true; }
        }

        public bool this[int x
            ,
            int y]
        {
            get { return true; }
        }

        public bool this[
            int x
            , int y]
        {
            get { return true; }
        }

        public bool this[
            int x
            ,
            int y
            ,
            int[,][] z]
        {
            get { return true; }
        }

        public bool this[
            int x

            ,int y]
        {
            get { return true; }
        }

        public bool this[
            int x

            , 
            int y]
        {
            get { return true; }
        }
    }
}

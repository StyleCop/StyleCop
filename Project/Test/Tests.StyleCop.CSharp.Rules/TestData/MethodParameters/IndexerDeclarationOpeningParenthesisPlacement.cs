namespace IndexerDeclarationOpeningParenthesisPlacement1
{
    using System;

    public class NormalMethods1
    {
        public bool this
            [int x]
        {
            get { return true; }
        }

        public bool this
            [
            short x]
        {
            get { return true; }
        }

        public bool this

            [long x]
        {
            get { return true; }
        }
    }
}

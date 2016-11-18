namespace IndexerDeclarationClosingParenthesisPlacement1
{
    using System;

    public class NormalMethods1
    {
        public bool this[int x
            ]
        {
            get { return true; }
        }

        public bool this[
            int x
            ]
        {
            get { return true; }
        }

        public bool this[
            int x,
            int y
            ]
        {
            get { return true; }

        }

        public bool this[
            int x,
            int y

            ]
        {
            get { return true; }
        }
    }
}

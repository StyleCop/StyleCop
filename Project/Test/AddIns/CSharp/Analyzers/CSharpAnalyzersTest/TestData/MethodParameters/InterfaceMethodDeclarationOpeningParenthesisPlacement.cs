namespace InterfaceMethodDeclarationOpeningParenthesisPlacement1
{
    using System;

    #region Normal Methods

    public interface NormalMethods1
    {
        // Invalid placement.
        public void Method4
            ();

        public void Method5
            (
            );

        public void Method6
            (int x);

        public void Metohd7
            (
            int x);

        public void Method8

            (int x);
    }

    #endregion Normal Methods
}

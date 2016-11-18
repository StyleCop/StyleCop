namespace InterfaceMethodDeclarationClosingParenthesisPlacement1
{
    using System;

    #region Normal Methods
    
    public interface NormalMethods1
    {
        // Invalid placement.
        public void Method5(

            );

        public void Method6(int x
            );

        public void Method7(
            int x
            );

        public void Method8(
            int x,
            int y
            );

        public void Method9(
            int x,
            int y

            );
    }

    #endregion Normal Methods
}

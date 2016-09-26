namespace InterfaceMethodDeclarationSpanningMultipleLines1
{
    using System;

    #region Normal Methods

    public interface NormalMethods1
    {
        // Invalid placement.
        public void Method1(int x, int 
            y);

        public void Method2(int x, out int
            y);

        public void Method3(int x, out 
            int y);

        public void Method4(
            int x, 
            int
            y);

        public void Method5(
            int x, 
            out int
            y);

        public void Method6(
            int x, 
            out 
            int y);

        public void Method7(int x, int y, int
            z);

        public void Method8(int x, int y, out int
            z);

        public void Method9(int x, int y, out 
            int z);

        public void Method10(
            int x, 
            int y, 
            int
            z);

        public void Method11(
            int x, 
            int y, 
            out int
            z);

        public void Method12(
            int x, 
            int y, 
            out 
            int z);
    }

    #endregion Normal Methods
}

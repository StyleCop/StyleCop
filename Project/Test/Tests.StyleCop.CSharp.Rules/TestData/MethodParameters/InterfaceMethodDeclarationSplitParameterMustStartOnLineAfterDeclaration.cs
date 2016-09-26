namespace InterfaceMethodDeclarationSplitParameterMustStartOnLineAfterDeclaration1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    #region Normal Methods
    
    public interface NormalMethods1
    {
        // Invalid placement.
        public void Method1(int x,
            int y);

        public void Method2(int x,
            int y, int z);

        public void Method3(int x,
            int y,
            int z);

        public void Method4(int x, int y,
            int z);

        public void Method5(int x, int y,
            int z, int a);

        public void Method6(int x, int y,
            int z, 
            int a);
    }

    #endregion Normal Methods
}

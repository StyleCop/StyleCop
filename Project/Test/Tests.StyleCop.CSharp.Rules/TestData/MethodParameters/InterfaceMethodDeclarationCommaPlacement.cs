namespace InterfaceMethodDeclarationCommaPlacement1
{
    using System;

    #region Normal Methods

    public interface NormalMethods1
    {
        // Invalid Placement
        public void Method7(int x
            , int y);

        public void Method8(int x
            ,
            int y);

        public void Method9(
            int x
            , int y);

        public void Method10(
            int x
            ,
            int y
            ,
            int z);

        public void Method11(
            int x

            ,int y);

        public void Method12(
            int x

            , 
            int y);
    }

    #endregion Normal Methods
}

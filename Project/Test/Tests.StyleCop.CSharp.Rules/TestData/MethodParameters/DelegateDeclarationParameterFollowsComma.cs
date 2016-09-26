namespace DelegateDeclarationParameterFollowsComma1
{
    using System;

    public class NormalDelegates1
    {
        public delegate void Delegate1(int x,
            
            int y);

        public delegate void Delegate2(
            int x, 
            
            int y);

        public delegate void Delegate3(
            int x,


            int y);

        public delegate void Delegate4(
            int x,
            int y,
            
            int z);

        public delegate void Delegate5(
            int x,
            int y,
            

            int z);
    }
}

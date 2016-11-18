namespace DelegateDeclarationSpanningMultipleLines1
{
    using System;

    public class NormalDelegates1
    {
        public delegate void Delegate1(int x, int 
            y);

        public delegate void Delegate2(int x, out int
            y);

        public delegate void Delegate3(int x, out 
            int y);

        public delegate void Delegate4(
            int x, 
            int
            y);

        public delegate void Delegate5(
            int x, 
            out int
            y);

        public delegate void Delegate6(
            int x, 
            out 
            int y);

        public delegate void Delegate7(int x, int y, int
            z);

        public delegate void Delegate8(int x, int y, out int
            z);

        public delegate void Delegate9(int x, int y, out 
            int z);

        public delegate void Delegate10(
            int x, 
            int y, 
            int
            z);

        public delegate void Delegate11(
            int x, 
            int y, 
            out int
            z);

        public delegate void Delegate12(
            int x, 
            int y, 
            out 
            int z);
    }
}

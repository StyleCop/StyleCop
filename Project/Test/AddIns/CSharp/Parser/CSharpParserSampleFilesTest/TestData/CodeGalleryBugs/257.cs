namespace TestWPF
{
    class Test
    {
        void testError()
        {
            unsafe
            {
                int*[] ptrArray = new int*[10];
            }
        }
    }
}
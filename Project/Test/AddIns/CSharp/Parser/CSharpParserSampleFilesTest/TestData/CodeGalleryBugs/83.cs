namespace TestWPF
{
    unsafe class Test
    {
        void testError()
        {
            fixed (byte* outPtr = buffer)
            {
                byte* outPtr8 = outPtr;
                inPtr16 = (ushort*)inPtr;
                double scale = 255.0 / maxValue;
                for (int i = 0; i < buffer.Length; i++)
                {
                    *outPtr8 = (byte)(*inPtr16 * scale);
                    outPtr8++;
                    inPtr16++;
                }
            }
        }
    }
}
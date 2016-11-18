namespace UnnecessaryUnsafe
{
    class Class1
    {
        public void NecessaryUnsafe()
        {
            unsafe
            {
                int x = 0;
            }
        }

        public void UnnecessaryUnsafe()
        {
            unsafe
            {
            }

            unsafe
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
        }
    }
}
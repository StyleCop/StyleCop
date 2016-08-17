namespace UnnecessaryLock
{
    class Class1
    {
        public void NecessaryLock()
        {
            lock (this)
            {
                int x = 0;
            }
        }

        public void UnnecessaryLock()
        {
            lock (this)
            {
            }

            lock (this)
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
        }
    }
}
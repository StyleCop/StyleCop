namespace UnnecessaryCheckedAndUnchecked
{
    class Class1
    {
        public void NecessaryCheckedAndUnchecked()
        {
            checked
            {
                int x = 0;
            }

            unchecked
            {
                int x = 0;
            }
        }

        public void UnnecessaryCheckedAndUnchecked()
        {
            checked
            {
            }

            unchecked
            {
            }

            checked
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }

            unchecked
            {
                // Contains comment
                /* Contains Multi-line comment */
                #region Contains Region
                #endregion
            }
        }
    }
}
namespace UnnecessaryLock
{
    class Class1
    {
        // Necessary since not static.
        public Class1()
        {
        }

        // Necessary since not static.
        public Class1(int x)
        {
            x = 2;
        }

        // Necessary since body contains code.
        static Class1()
        {
            int x;
        }
    }

    class Class2
    {
        // Unnecessary since body is empty.
        static Class2()
        {
        }
    }

    class Class3
    {
        // Unnecessary since body contains no code.
        static Class3()
        {

            // Contains comment
            /* Contains Multi-line comment */
            #region Contains Region
            #endregion

        }
    }
}
namespace CSharpAnalyzersTest.TestData.Documentation
{
    /// <summary>
    /// Test message 1.
    /// </summary>
    /// <typeparam name="T"></typeparam> 
    class DocumentationGenericTypeParameters
    {
        /// <summary> 
        /// Creates a new array of arbitrary type <typeparamref name="T"/>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        public static T[] Method1<T>(int n)
        {
            return new T[n];
        }

        /// <summary>
        /// Test message 2.
        /// </summary>
        /// <param name="args">Test message 3.</param>
        /// <typeparam name="T"></typeparam>
        public static void Method2(string[] args)
        {
        }

        /// <summary> 
        /// Creates a new array of arbitrary type <typeparamref name="T"/>
        /// </summary> 
        /// <typeparam name="S"></typeparam>
        public static T[] Method3<T>(int n)
        {
            return new T[n];
        }
    }
}
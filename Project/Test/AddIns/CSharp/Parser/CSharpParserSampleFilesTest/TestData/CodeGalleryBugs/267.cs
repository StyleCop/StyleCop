namespace Nito
{
    /// <summary>
    /// Class that reproduces SA0001: IndexOutOfRangeException.
    /// </summary>
    internal class Repro
    {
        /// <summary>
        /// A method that reproduces SA0001: IndexOutOfRangeException.
        /// </summary>
        /// <returns>Nothing really meaningful.</returns>
        public int Test()
        {
            // Changing the "_" to "x" in these lines avoids the error.
            int _ = 0;
            return _;
        }
    }
}

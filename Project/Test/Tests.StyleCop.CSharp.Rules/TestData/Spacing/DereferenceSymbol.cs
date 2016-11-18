namespace CSharpAnalyzersTest.TestData.Spacing
{
    using System.Security;

    class DereferenceSymbol
    {
        public static void Main(string[] args)
        {
            var password = "Password";
            unsafe
            {
                fixed (char* passwordPointer = password.ToCharArray()) // valid
                {
                    var securePassword = new SecureString(passwordPointer, password.Length);
                }

                fixed (char * passwordPointer = password.ToCharArray()) // not valid
                {
                    var securePassword = new SecureString(passwordPointer, password.Length);
                }
            }
        }
    }
}

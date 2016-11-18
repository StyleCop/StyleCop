namespace CSharpAnalyzersTest.TestData
{
    using System;

    /// <summary>
    /// This is a class.
    /// </summary>
    public class Program
    {
        public string UserName { get { return null; } }
        public string UserPassword { get { return null; } }
        public string Authority { get { return null; } }

        public void Method()
        {
            ConnectionOptions options1 = new ConnectionOptions
            {
                Username = this.UserName,
                Password = this.UserPassword,
                Authority = this.Authority
            };

            ConnectionOptions options2 = new ConnectionOptions
            {
                Username = UserName,
                Password = this.UserPassword,
                Authority = this.Authority
            };

            ConnectionOptions options3 = new ConnectionOptions
            {
                Username = this.UserName,
                Password = UserPassword,
                Authority = this.Authority
            };
            
            ConnectionOptions options4 = new ConnectionOptions
            {
                Username = this.UserName,
                Password = this.UserPassword,
                Authority = Authority
            };

            ConnectionOptions options5 = new ConnectionOptions
            {
                Username = this.UserName,
                Password = "yxz" + UserPassword,
                Authority = this.Authority
            };
        }
    }
}

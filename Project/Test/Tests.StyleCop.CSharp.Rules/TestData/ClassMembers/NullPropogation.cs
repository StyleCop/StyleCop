namespace CSharpAnalyzersTest.TestData.NullPropogation
{
    public class NullPropogationCollaborator
    {
        public string Method1()
        {
            return string.Empty;
        }
    }

    public class Class1
    {
        private NullPropogationCollaborator field;

        public string Method2()
        {
            return this.field?.Method1(); // Valid because method doesn't exist in this class
        }
    }

    public class Class2
    {
        private NullPropogationCollaborator field;

        public string Method1()
        {
            this.field?.Method1(); // Valid because it isn't refering to this class.
            this.field?
                .Method1();
            this.field?.
                 Method1();
            this.field
                ?.Method1();
        }

        public string Method2()
        {
            this.field?.Method1()?.Trim(); // Valid
        }
    }
}

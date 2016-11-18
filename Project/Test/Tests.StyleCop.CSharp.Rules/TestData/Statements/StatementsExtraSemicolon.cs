namespace StatementsExtraSemicolon
{
    public enum MyEnum
    {
        Item
    };

    public class MyClass
    {
        public bool Property1
        {
            get
            {
                return true;;
            }
        }
    };

    // There is a special case where an empty statement is allowed. In some cases, a label statement must be used to mark the end of a 
    // scope. C# requires that labels have at least one statement after them. In the developer wants to use a label to mark the end of the
    // scope, he does not want to put a statement after the label. The best course of action is to insert a single semicolon here.
    public class SemicolonAfterLabel
    {
        public void Method()
        {
            if (true)
            {
                goto end;
            }

            // This semicolon is allowed.
            end:;
        }
    }
};
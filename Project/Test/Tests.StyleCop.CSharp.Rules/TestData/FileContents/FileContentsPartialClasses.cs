// Tests that no violations are thrown when there are two partial classes of the same type in a file.
namespace FileContentsPartialClass
{
    public partial class Class1
    {
    }

    public partial class Class1
    {
    }
}
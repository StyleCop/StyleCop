public class Test
{ }

public class SwitchCaseNameOfClass
{
    private void SwitchCaseNameOf()
    {
        Test test = new Test();
        string CompanyFolderModel = "test";
        Test result = null;
        string name = "test";

        switch (typeof(Test).Name)
        {
            case nameof(CompanyFolderModel):
                result = this.GetCompanyFolderModel(name) as Test;
                break;
        }
    }

    private Test GetCompanyFolderModel(object name)
    {
        throw new NotImplementedException();
    }
}

public class Test
{
    public int SearchAsync { get; set; }
}

public class Program
{
    public Test index { get; set; }

    public void Test()
    {
        Console.WriteLine(nameof(index));
        Console.WriteLine(nameof(index.SearchAsync));
        Console.WriteLine(nameof(this.index.SearchAsync));
    }
}
namespace CSharpParserTest.TestData
{
    public class IndexInitializersExpressions
    {
        private Dictionary<string, int> letters2 = new Dictionary<string, int>
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3,
        };

        private Dictionary<int, int> integers = new Dictionary<int, int>
        {
            [5] = 1,
            [3] = 2,
            [4] = 3,
        };

        private Dictionary<int, People> peoples = new Dictionary<int, People>
        {
            [5] = new People() { Name = "test" },
            [3] = new People() { Name = "test" },
            [4] = new People() { Name = "test" },
        };

        private Dictionary<int, int> singleLine = new Dictionary<int, int> { [0] = 0 };

        public void InitializeDictionary()
        {
            var dictionary = new Dictionary<string, string> { ["key"] = "value" };
        }
    }
}

 

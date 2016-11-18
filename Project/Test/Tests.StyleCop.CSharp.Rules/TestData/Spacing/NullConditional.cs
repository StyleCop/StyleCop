using System.Collections.Generic;
using System.Linq;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    internal class NullConditional
    {
        private void Method1()
        {
            List<string> list = new List<string>();
            var method1 = list?.FirstOrDefault();
            method1 = list ?.FirstOrDefault();
            method1 = list?. FirstOrDefault();
            method1 = list ?. FirstOrDefault();
            method1 = list?.FirstOrDefault()?.FirstOrDefault()?.FirstOrDefault();
            method1 = list ?.FirstOrDefault()?.FirstOrDefault()?.FirstOrDefault();
            method1 = list?. FirstOrDefault()?.FirstOrDefault()?.FirstOrDefault();
            method1 = list ?. FirstOrDefault()?.FirstOrDefault()?.FirstOrDefault();
            method1 = list?.FirstOrDefault() ?.FirstOrDefault()?.FirstOrDefault();
            method1 = list?.FirstOrDefault()?. FirstOrDefault()?.FirstOrDefault();
            method1 = list?.FirstOrDefault() ?. FirstOrDefault()?.FirstOrDefault();
            method1 = list?.FirstOrDefault()?.FirstOrDefault() ?.FirstOrDefault();
            method1 = list?.FirstOrDefault()?.FirstOrDefault()?. FirstOrDefault();
            method1 = list?.FirstOrDefault()?.FirstOrDefault() ?. FirstOrDefault();
        }
    }

    public class NullConditionalNextTest
    {
        // test for this issue https://github.com/Visual-Stylecop/Visual-StyleCop/issues/10
        public void TestId10Issue()
        {
            var posts = new List<string>() { "abc", "123" };
            posts.First()?.Replace('a', 'z'); // allowed
            posts.First()?. Replace('a', 'z'); // not allowed
            posts.First() ?.Replace('a', 'z'); // not allowed
            posts.First() ?. Replace('a', 'z'); // not allowed
            posts.First()? .Replace('a', 'z'); // not allowed
            var property = node["properties"]?["property"]; // allowed
            var property = node["properties"] ?["property"]; // not allowed
            var property = node["properties"]? ["property"]; // not allowed
            var property = node["properties"] ? ["property"]; // not allowed
        }
    }

    public class SA1029DoNotSplitNullConditionalOperators
    {
        public void SplitNullConditionOperator()
        {
            // Allowed
            foo?.Bar();

            // Allowed
            foo
                ?.Bar();

            // Allowed
            foo?.
                Bar();

            // Not allowed
            foo?
              .Bar();

            // Not allowed
            foo? // comment
              .Bar();

            // Allowed
            foo?[index];

            // Not allowed
            foo?
              [index];

            // Not allowed
            foo? // comment
              [index];
        }
    }
}

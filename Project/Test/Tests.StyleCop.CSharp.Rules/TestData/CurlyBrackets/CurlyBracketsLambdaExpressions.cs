using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsLambdaExpressions
    {
        private void TestLambdaExpressions()
        {
            // Valid
            MethodInvocationHandler item = (a, b) => { };
            MethodInvocationHandler item2 = (a, b) => { int x; };
            // Invalid
            MethodInvocationHandler item3 = (a, b) => 
            { 
                int x; };

            MethodInvocationHandler item = (a, b) => { 
                int x; 
            };

            MethodInvocationHandler item = (a, b) => {
                int x; };

            MethodInvocationHandler item = (a, b) =>  
            { 
                int x; };

            MethodInvocationHandler item = (a, b) => 
            { int x;
            };

            MethodInvocationHandler item = (a, b) => 
            { int x; };

            this.Method((a, b) => 
            {
                int x; });

            this.Method((a, b) => {
                int x;
            });

            this.Method((a, b) => {
                int x; });

            this.Method((a, b) => 
            {
                int x; });

            this.Method((a, b) => 
            { int x;
            });

            this.Method((a, b) => 
            { int x; });

            // Valid lambda expressions.
            MethodInvocationHandler item = (a, b) =>  
            { 
            };

            MethodInvocationHandler item = (a, b) =>  
            {
                int x;
            };

            this.Method((a, b) => { int x; });

            this.Method((a, b) =>  
            { 
                int x; 
            });
        }
    }

    public class LambdasWrappedInBrackets
    {
        private void TestLambdaExpressions()
        {
            // Test that lambdas wrapped inside of parenthesis or brackets are allowed to be trailed by other kinds of expressions.

            var x = this.Method((a, b) =>
            {
                int x;
            });

            var y = this.Method((a, b) =>
            {
                int x;
            }).ToString();

            var z = this.Method((a, b) =>
            {
                int x;
            }) as object;

            var aa = new int[(a, b) =>
            {
                int x;
            }];

            this.Method1((a, b) => { int x; }, () => { int y; }, (() => { int z; }));
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            }.ToDictionary(i => i.Key);
            }
        }

        // THis tests that the select on the newline after the closing curly bracket is allowed
        public void TestClosingCurlyBracketFollowedBySelect()
        {
            var enumValues = from frameworkName in frameworks.Cast<string>()
            let fx = new FrameworkName(frameworkName)
            let ev = new EnumValue
            {
                Name = fx.FullName,
                DisplayName = string.IsNullOrEmpty(fx.Profile) ? string.Format(CultureInfo.InvariantCulture, "{0} {1}", fx.Identifier, fx.Version) : string.Format(CultureInfo.InvariantCulture, "{0} {1} ({2})", fx.Identifier, fx.Version, fx.Profile),
            }
            select new PageEnumValue(ev);
        }

        public void a()
        {
            var aValue = aBoolean
            ? new MyType
            {
                Something = SomeValue,
                SomethingElse = SomethingOtherValue
            }
            : new MyType
            {
                Something = SomeValue2,
                SomethingElse = SomethingOtherValue2
            };
        }
    }

    public class CurlyBracketsLambdasWithObjectAndCollectionInitializers
    {
        public void Method()
        {
            Func<string> func;

            // Valid
            func = () => string.Format(
                "{0}{1}{2}",
                new[] { 'a', 'b' },
                new[] { 1, 2 },
                new { Name = "Test Name" });
            func = () => string.Format(
                "{0}{1}{2}",
                new List<char> { 'a', 'b' },
                new List<int> { 1, 2 },
                new { Name = "Test Name" });
            func = () => string.Format(
                "{0}{1}{2}",
                new List<char>
                {
                    'a',
                    'b'
                },
                new List<int>
                {
                    1, 2
                },
                new
                {
                    Name = "Test Name"
                });

            // Invalid
            func = () => string.Format(
                "{0}{1}{2}",
                new[] { 'a', 'b'
                },
                new[] { 1, 2
                },
                new { Name = "Test Name"
                });
            func = () => string.Format(
                "{0}{1}{2}",
                new List<char> {
                    'a', 'b' },
                new List<int> {
                    1, 2 },
                new {
                    Name = "Test Name" });

            // Valid
            func = () =>
            {
                return string.Format(
                    "{0}{1}{2}",
                    new[] { 'a', 'b' },
                    new[] { 1, 2 },
                    new { Name = "Test Name" });
            };
            func = () =>
            {
                return string.Format(
                    "{0}{1}{2}",
                    new List<char> { 'a', 'b' },
                    new List<int> { 1, 2 },
                    new { Name = "Test Name" });
            };
            func = () =>
            {
                return string.Format(
                    "{0}{1}{2}",
                    new List<char>
                    {
                        'a',
                        'b'
                    },
                    new List<int>
                    {
                        1, 2
                    },
                    new
                    {
                        Name = "Test Name"
                    });
            };

            // Invalid
            func = () =>
            {
                return string.Format(
                    "{0}{1}{2}",
                    new[] { 'a', 'b'
                    },
                    new[] { 1, 2
                    },
                    new { Name = "Test Name"
                    });
            };
            func = () =>
            {
                return string.Format(
                    "{0}{1}{2}",
                    new List<char> {
                        'a', 'b' },
                    new List<int> {
                        1, 2 },
                    new {
                        Name = "Test Name" });
            };
        }
    }
}
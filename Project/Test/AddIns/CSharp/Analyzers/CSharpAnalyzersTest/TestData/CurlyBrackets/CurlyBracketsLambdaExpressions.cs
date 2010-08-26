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
    }
}
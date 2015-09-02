using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Parenthesis
{
    [Serializable] 
    class AttributeConstructorParenthesisValid1
    {
        [Serializable]
        private void ValidMethod1()
        {
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    class AttributeConstructorParenthesisValid2 : Attribute
    {
        [AttributeUsage(AttributeTargets.All)]
        private void ValidMethod1()
        {
        }
    }

    [Serializable()]
    class AttributeConstructorParenthesisInvalid1
    {
        [Serializable()]
        private void InvalidMethod1()
        {
        }
    }

    [Serializable]
    struct AttributeConstructorParenthesisValid1
    {
        [Serializable]
        private void ValidMethod1()
        {
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    struct AttributeConstructorParenthesisValid2 : Attribute
    {
        [AttributeUsage(AttributeTargets.All)]
        private void ValidMethod1()
        {
        }
    }

    [Serializable()]
    struct AttributeConstructorParenthesisInvalid1
    {
        [Serializable()]
        private void InvalidMethod1()
        {
        }
    }
}

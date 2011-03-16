//-----------------------------------------------------------------------
// <copyright file="UnitTest1.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace CodeUnitPropertiesTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using StyleCop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    using StyleCop.CSharp.CodeModel;
    using System.IO;
    using System.Collections;

    [TestClass]
    public class UnitTest1
    {
        ////[TestMethod]
        public void TestNamespace()
        {
            string sourceCode =
@"namespace Namespace1
{
    public class Class1
    {
    }
}";
            CsLanguageService languageService = new CsLanguageService();
            CsDocument document1 = languageService.CreateCodeModel(sourceCode, "source1.cs", "test");
            CsDocument document2 = languageService.CreateCodeModel(sourceCode, "source2.cs", "test");

            Comparer comparer = new Comparer();
            comparer.AreEqual(document1, document2);
        }
    }
}

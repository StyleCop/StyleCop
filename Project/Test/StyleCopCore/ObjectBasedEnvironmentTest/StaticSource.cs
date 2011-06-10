// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticSource.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   The static source.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ObjectBasedEnvironmentTest
{
    /// <summary>
    /// The static source.
    /// </summary>
    public static class StaticSource
    {
        #region Constants and Fields

        public static string Source1 =
            @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectBasedEnvironmentTest
{
    class Class1
    {
    }
}";

        public static string Source2 =
            @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectBasedEnvironmentTest
{
    class Class2
    {
    }
}";

        public static string Source3 =
            @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectBasedEnvironmentTest
{
    class Class3
    {
    }
}";

        public static string[] Sources = new[] { Source1, Source2, Source3 };

        #endregion
    }
}
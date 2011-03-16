//-----------------------------------------------------------------------
// <copyright file="StaticSource.cs">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBasedEnvironmentTest
{
    public static class StaticSource
    {
        public static string Source1 =
            @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamBasedEnvironmentTest
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

namespace StreamBasedEnvironmentTest
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

namespace StreamBasedEnvironmentTest
{
    class Class3
    {
    }
}";

        public static string[] Sources = new string[]
        {
            Source1,
            Source2,
            Source3
        };
    }
}

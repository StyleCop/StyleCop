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

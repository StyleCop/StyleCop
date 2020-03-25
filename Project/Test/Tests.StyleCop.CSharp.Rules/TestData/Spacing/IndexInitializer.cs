using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.StyleCop.CSharp.Rules.TestData.Spacing
{
    class IndexInitializer
    {
        static void InitializeInt()
        {
            var dict = new Dictionary<int, People>
            {
                [ 1 ] = new People( ),
            };
        }

        public void InitializeString()
        {
            var dictionary = new Dictionary<string, string> { [ "key" ] = "value" };
        }

        private Dictionary<int, People> peoples = new Dictionary<int, People>
        {
            [3]=new People(){Name="test"},
            [ 5 ] = new People( ) { Name = "test" },
        };
    }
}

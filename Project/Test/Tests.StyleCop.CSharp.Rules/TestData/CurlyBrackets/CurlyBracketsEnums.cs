using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsEnums
    {
        // Invalid enums
        public enum InvalidEnum1 { }
        public enum InvalidEnum2 { Item }

        public enum InvalidEnum3 {
            Item }

        public enum InvalidEnum4 {
            Item 
        }

        public enum InvalidEnum5 
        {
            Item }

        public enum InvalidEnum6
        { Item 
        }
        
        public enum InvalidEnum7
        { Item }

        // Valid enums
        public enum ValidEnum1
        {
        }

        public enum ValidEnum2
        {
            Item 
        }
    }
}
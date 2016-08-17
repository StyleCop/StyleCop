using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsStructs
    {
        // Invalid structs
        public struct InvalidStruct1 { }
        public struct InvalidStruct2 { private int field; }

        public struct InvalidStruct3 {
            private int field; }

        public struct InvalidStruct4 {
            private int field; 
        }
        
        public struct InvalidStruct5 
        {
            private int field; }

        public struct InvalidStruct6
        { private int field; 
        }

        public struct InvalidStruct7
        { private int field; }

        // Valid structs
        public struct ValidStruct1
        {
        }

        public struct ValidStruct2
        { 
            private int field; 
        }
    }
}